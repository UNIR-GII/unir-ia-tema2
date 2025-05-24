namespace SearchAI.Models;

public class Node<T>
{
    public Node(T state, Node<T>? parent = null, string? action = null, int cost = 0)
    {
        State = state;
        Parent = parent;
        Action = action;
        Cost = cost;
    }

    public T State { get; set; }
    public Node<T>? Parent { get; set; }
    public string? Action { get; set; }
    public int Cost { get; set; }

    public IEnumerable<T> GetPath()
    {
        var path = new Stack<T>();
        var current = this;
        while (current != null)
        {
            path.Push(current.State);
            current = current.Parent!;
        }

        return path;
    }
}