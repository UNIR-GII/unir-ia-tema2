using SearchAI.Models;

namespace SearchAI.Algorithms;

public interface ISearchAlgorithm<T>
{
    SearchResult<T>? Search(SearchProblem<T> problem);
}