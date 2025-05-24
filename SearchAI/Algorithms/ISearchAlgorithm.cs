using SearchAI.Models;

namespace SearchAI.Algorithms;

public interface ISearchAlgorithm<T>
{
    Node<T>? Search(SearchProblem<T> problem);
}