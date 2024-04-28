using DepthFirstAndBreadthFirstSearch;

Console.WriteLine("Hello, World!");

var graph = new Dictionary<string, string[]>()
{
    { "a", ["c", "b"] },
    { "b", ["d"] },
    { "c", ["e"] },
    { "d", ["f"] },
    { "e", [] },
    { "f", [] },
};


Console.WriteLine("Depth First Search:");
Algorithms.DepthFirstPrint(graph, "a");

Console.WriteLine("Depth First Recursive Search:");
Algorithms.DepthFirstRecursivePrint(graph, "a");

Console.WriteLine("Breadth First Search:");
Algorithms.BreadthFirstPrint(graph, "a");