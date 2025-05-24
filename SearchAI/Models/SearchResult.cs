namespace SearchAI.Models;

public class SearchResult<T>
{
    public Node<T>? GoalNode { get; set; }

    // Métricas lógicas
    public int NodesGenerated { get; set; }
    public int NodesExpanded { get; set; }
    public int MaxFrontierSize { get; set; }
    public int MaxDepth { get; set; }

    // Métricas de tiempo
    public TimeSpan ElapsedTime { get; set; }
    public TimeSpan ComputationTime { get; set; }
    public long StartTicks { get; set; }
    public long EndTicks { get; set; }
    public long TotalTicks => EndTicks - StartTicks;

    public IEnumerable<T> GetPath()
    {
        return GoalNode?.GetPath() ?? Enumerable.Empty<T>();
    }
}