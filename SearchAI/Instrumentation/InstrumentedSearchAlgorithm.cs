using System.Diagnostics;
using SearchAI.Models;
using SearchAI.Algorithms;

namespace SearchAI.Instrumentation;

public class InstrumentedSearchAlgorithm<T>(ISearchAlgorithm<T> inner)
{
    private readonly ISearchAlgorithm<T> _inner = inner;

    public SearchResult<T> Search(SearchProblem<T> problem)
    {
        var result = new SearchResult<T>();
        var swGlobal = Stopwatch.StartNew();
        result.StartTicks = Stopwatch.GetTimestamp();

        var swLogic = Stopwatch.StartNew();

        var frontier = new Queue<Node<T>>();
        var explored = new HashSet<T>();

        frontier.Enqueue(new Node<T>(problem.InitialState));
        result.NodesGenerated++;
        result.MaxFrontierSize = 1;

        while (frontier.Count > 0)
        {
            result.MaxFrontierSize = Math.Max(result.MaxFrontierSize, frontier.Count);
            var node = frontier.Dequeue();
            result.NodesExpanded++;
            result.MaxDepth = Math.Max(result.MaxDepth, node.Cost);

            if (problem.IsGoal(node.State))
            {
                result.GoalNode = node;
                break;
            }

            explored.Add(node.State);

            foreach (var (state, action, cost) in problem.GetSuccessors(node.State))
            {
                if (!explored.Contains(state) && !frontier.Any(n => n.State!.Equals(state)))
                {
                    frontier.Enqueue(new Node<T>(state, node, action, node.Cost + cost));
                    result.NodesGenerated++;
                }
            }
        }

        swLogic.Stop();
        swGlobal.Stop();

        result.ComputationTime = swLogic.Elapsed;
        result.ElapsedTime = swGlobal.Elapsed;
        result.EndTicks = Stopwatch.GetTimestamp();

        return result;
    }
}