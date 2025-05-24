using SearchAI.Models;

namespace SearchAI.Algorithms;

public class BreadthFirstSearch<T> : ISearchAlgorithm<T>
{
    public Node<T>? Search(SearchProblem<T> problem)
    {
        var frontier = new Queue<Node<T>>();
        var explored = new HashSet<T>();
        frontier.Enqueue(new Node<T>(problem.InitialState));

        while (frontier.Count > 0)
        {
            var node = frontier.Dequeue();

            if (problem.IsGoal(node.State))
                return node;

            explored.Add(node.State);

            foreach (var (state, action, cost) in problem.GetSuccessors(node.State))
                if (!explored.Contains(state) && !frontier.Any(n => n.State!.Equals(state)))
                    frontier.Enqueue(new Node<T>(state, node, action, node.Cost + cost));
        }

        return null; // No path found
    }
}