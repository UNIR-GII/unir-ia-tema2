using System.Diagnostics;
using SearchAI.Algorithms;
using SearchAI.SampleProblems;

while (true)
{
    Console.Clear();
    Console.WriteLine("🌐 UNIR - Tema 2 - Algoritmos de Búsqueda");
    Console.WriteLine("Seleccione un algoritmo:");
    Console.WriteLine("1. Búsqueda en Anchura (BFS)");
    Console.WriteLine("2. Búsqueda en Profundidad (DFS)");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");

    var option = Console.ReadLine();
    ISearchAlgorithm<string>? algorithm = option switch
    {
        "1" => new BreadthFirstSearch<string>(),
        "2" => new DepthFirstSearch<string>(),
        "0" => null,
        _ => null
    };

    if (option == "0" || algorithm == null)
    {
        Console.WriteLine("👋 Saliendo del programa.");
        break;
    }

    var problem = CityMapProblem.Create();
    var result = algorithm.Search(problem);

    Console.WriteLine();
    if (result is not null)
    {
        Console.WriteLine("✅ Ruta encontrada:");
        foreach (var city in result.GetPath())
            Console.WriteLine($" - {city}");
        Console.WriteLine($"Total de pasos: {result.Cost}");
    }
    else
    {
        Console.WriteLine("❌ No se encontró un camino.");
    }

    Console.WriteLine("\n🔍 Métricas detalladas:");
    Console.WriteLine($" - Nodos generados: {result.NodesGenerated}");
    Console.WriteLine($" - Nodos expandidos: {result.NodesExpanded}");
    Console.WriteLine($" - Profundidad alcanzada: {result.MaxDepth}");
    Console.WriteLine($" - Tamaño máximo de la frontera: {result.MaxFrontierSize}");
    Console.WriteLine($" - Longitud de la solución: {result.GetPath().Count() - 1}");
    Console.WriteLine($" - Tiempo total de búsqueda: {result.ElapsedTime.TotalMilliseconds:F2} ms");
    Console.WriteLine($" - Tiempo lógico de computación: {result.ComputationTime.TotalMilliseconds:F2} ms");
    Console.WriteLine($" - Tics de reloj (CPU): {result.TotalTicks} ticks");
    
    var proc = Process.GetCurrentProcess();
    Console.WriteLine($" - Tiempo de CPU real (usuario + kernel): {proc.TotalProcessorTime.TotalMilliseconds:F2} ms");
    
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}