namespace SearchAI.Models;

public class SearchProblem<T>
{
    public SearchProblem(T initialState, Func<T, bool> isGoal,
        Func<T, IEnumerable<(T, string, int)>> getSuccessors)
    {
        InitialState = initialState;
        IsGoal = isGoal;
        GetSuccessors = getSuccessors;
    }

    public T InitialState { get; }
    public Func<T, bool> IsGoal { get; }
    public Func<T, IEnumerable<(T state, string action, int cost)>> GetSuccessors { get; }
}