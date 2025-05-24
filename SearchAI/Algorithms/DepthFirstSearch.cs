using System.Diagnostics;
using SearchAI.Models;

namespace SearchAI.Algorithms;

public class DepthFirstSearch<T> : ISearchAlgorithm<T>
{
    public SearchResult<T> Search(SearchProblem<T> problem)
    {
        var swGlobal = Stopwatch.StartNew();
        var result = new SearchResult<T>
        {
            StartTicks = Stopwatch.GetTimestamp()
        };

        var frontier = new Stack<Node<T>>();
        var explored = new HashSet<T>();

        frontier.Push(new Node<T>(problem.InitialState));
        result.NodesGenerated++;
        result.MaxFrontierSize = 1;

        var swLogic = new Stopwatch();
        swLogic.Start();

        while (frontier.Count > 0)
        {
            result.MaxFrontierSize = Math.Max(result.MaxFrontierSize, frontier.Count);
            var node = frontier.Pop();
            result.NodesExpanded++;
            result.MaxDepth = Math.Max(result.MaxDepth, node.Cost);

            if (problem.IsGoal(node.State))
            {
                result.GoalNode = node;
                break;
            }

            if (explored.Contains(node.State))
                continue;

            explored.Add(node.State);

            foreach (var (state, action, cost) in problem.GetSuccessors(node.State).Reverse())
            {
                if (!explored.Contains(state))
                {
                    frontier.Push(new Node<T>(state, node, action, node.Cost + cost));
                    result.NodesGenerated++;
                }
            }
        }

        swLogic.Stop();
        swGlobal.Stop();

        result.EndTicks = Stopwatch.GetTimestamp();
        result.ComputationTime = swLogic.Elapsed;
        result.ElapsedTime = swGlobal.Elapsed;

        return result;
    }
}