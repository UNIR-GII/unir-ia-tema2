using SearchAI.Models;

namespace SearchAI.SampleProblems;

public static class CityMapProblem
{
    public static SearchProblem<string> Create()
    {
        var connections = new Dictionary<string, List<string>>
        {
            ["Madrid"] = new() { "Guadalajara", "Toledo" },
            ["Guadalajara"] = new() { "Madrid", "Zaragoza", "Cuenca" },
            ["Toledo"] = new() { "Madrid", "Ciudad Real" },
            ["Ciudad Real"] = new() { "Toledo" },
            ["Cuenca"] = new() { "Guadalajara", "Teruel" },
            ["Zaragoza"] = new() { "Guadalajara", "Barcelona" },
            ["Teruel"] = new() { "Cuenca" },
            ["Barcelona"] = new() { "Zaragoza" }
        };

        return new SearchProblem<string>(
            "Madrid",
            state => state == "Barcelona",
            state =>
                connections[state].Select(city => (city, $"Go to {city}", 1))
        );
    }
}