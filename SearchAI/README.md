# 🔍 AI Search Framework (.NET 9, C#)

Este repositorio proporciona una **infraestructura modular, extensible y profesional** para implementar y evaluar algoritmos de búsqueda en el contexto de Inteligencia Artificial. La lógica de los algoritmos está desacoplada de la instrumentación, permitiendo mantener un código limpio, testable y fácilmente ampliable.

---

## 🎯 Objetivos

- Implementar algoritmos clásicos de búsqueda (BFS, DFS, A*, etc.)
- Separar lógica de búsqueda de medición de rendimiento
- Proveer métricas de ejecución detalladas
- Permitir comparaciones objetivas entre algoritmos
- Favorecer una arquitectura clara y extensible

---

## 🧱 Estructura del Proyecto

```

SearchAI/
├── Algorithms/              # Algoritmos puros (sin métricas)
│   ├── ISearchAlgorithm.cs
│   ├── BreadthFirstSearch.cs
│   └── DepthFirstSearch.cs
├── Instrumentation/        # Instrumentación y decoradores de métricas
│   └── InstrumentedSearchAlgorithm.cs
├── Models/                 # Clases base del dominio
│   ├── Node.cs
│   ├── SearchProblem.cs
│   └── SearchResult.cs
├── SampleProblems/         # Problemas de ejemplo (como mapas de ciudades)
│   └── CityMapProblem.cs
├── Program.cs              # Punto de entrada con menú de consola
├── SearchAI.csproj         # Proyecto .NET 8
└── README.md

````

---

## 🧠 Clases Base

### `Node<T>`
Representa un nodo del espacio de estados.

- `State`: estado actual.
- `Parent`: nodo padre.
- `Action`: acción realizada para llegar aquí.
- `Cost`: coste acumulado desde el inicio.
- `GetPath()`: reconstruye el camino desde el nodo raíz.

---

### `SearchProblem<T>`
Modelo de un problema de búsqueda.

- `InitialState`: estado inicial.
- `IsGoal`: función que indica si un estado es objetivo.
- `GetSuccessors`: función generadora de sucesores, devuelve `(estado, acción, coste)`.

---

## 🔌 Interfaz de Algoritmo

### `ISearchAlgorithm<T>`

```csharp
Node<T>? Search(SearchProblem<T> problem);
````

Los algoritmos implementan esta interfaz y están completamente desacoplados de métricas o IO.

---

## 📏 Medición de rendimiento

### `InstrumentedSearchAlgorithm<T>`

Clase decoradora que envuelve cualquier `ISearchAlgorithm<T>` y devuelve un `SearchResult<T>` con métricas:

* `NodesGenerated`: número de nodos generados.
* `NodesExpanded`: número de nodos expandidos (extraídos de la frontera).
* `MaxFrontierSize`: tamaño máximo de la frontera durante la búsqueda.
* `MaxDepth`: profundidad máxima alcanzada.
* `ElapsedTime`: tiempo total de ejecución.
* `ComputationTime`: tiempo dedicado al procesamiento lógico.
* `TotalTicks`: tics de reloj transcurridos.
* `GoalNode`: nodo objetivo si se alcanzó.

---

## 🖥️ Ejecución

Puedes ejecutar el menú interactivo con:

```bash
dotnet run
```

Y seleccionar un algoritmo para resolver el problema cargado.

---

## 🔄 Ejemplo de uso

```csharp
var problem = CityMapProblem.Create();
var algorithm = new BreadthFirstSearch<string>();
var instrumented = new InstrumentedSearchAlgorithm<string>(algorithm);

SearchResult<string> result = instrumented.Search(problem);
```

---

## 🛠 Extensiones sugeridas

* Algoritmos adicionales: A\*, Greedy, IDDFS, UCS.
* Problemas adicionales: laberintos, puzzles, mapas con pesos.
* Exportación de métricas a CSV/JSON.
* Visualización de rutas o árboles.

---

## 📄 Licencia

Este proyecto está desarrollado como apoyo a estudios universitarios de Inteligencia Artificial. Puedes reutilizarlo y adaptarlo para fines educativos y personales.

---

## 📚 Otras páginas (en construcción)

* [📦 Algoritmos implementados](docs/algoritmos.md)
* [🗺 Ejemplos de problemas](docs/ejemplos.md)
* [📊 Comparativas y benchmarking](docs/benchmarking.md)