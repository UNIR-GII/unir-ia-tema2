using SearchAI.Models;

namespace SearchAI.Algorithms;

public class DepthFirstSearch<T> : ISearchAlgorithm<T>
{
    public Node<T>? Search(SearchProblem<T> problem)
    {
        var frontier = new Stack<Node<T>>();
        var explored = new HashSet<T>();
        frontier.Push(new Node<T>(problem.InitialState));

        while (frontier.Count > 0)
        {
            var node = frontier.Pop();

            if (problem.IsGoal(node.State))
                return node;

            if (explored.Contains(node.State))
                continue;

            explored.Add(node.State);

            foreach (var (state, action, cost) in problem.GetSuccessors(node.State).Reverse())
            {
                if (!explored.Contains(state))
                {
                    frontier.Push(new Node<T>(state, node, action, node.Cost + cost));
                }
            }
        }

        return null;
    }
}