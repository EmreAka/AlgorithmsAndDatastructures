Console.WriteLine("Shortest Path Algorithm!");

string[][] edges = [
    ["w", "x"],
    ["x", "y"],
    ["z", "y"],
    ["z", "v"],
    ["w", "v"]
];

var graph = BuildGraph(edges);

var shortestPath = GetShortestPath(graph, "w", "z");

Console.WriteLine($@"Shortest path is: {shortestPath}");
return;

static int GetShortestPath(Dictionary<string, List<string>> graph, string start, string target)
{
    var visited = new HashSet<(string, int)>();
    
    var queue = new Queue<(string, int)>();
    queue.Enqueue((start, 0));

    while (queue.Count > 0)
    {
        var current = queue.Dequeue();
        
        if (current.Item1 == target) return current.Item2;

        if (!visited.Contains(current))
        {
            visited.Add(current);

            var distance = current.Item2 + 1;
            
            foreach (var neighbor in graph[current.Item1])
            {
                queue.Enqueue((neighbor, distance));
            }    
        }
    }

    return 0;
}

static Dictionary<string, List<string>> BuildGraph(string[][] edges)
{
    var graph = new Dictionary<string, List<string>>();

    foreach (var edge in edges)
    {
        var from = edge.First();
        var to = edge.Last();

        if (!graph.ContainsKey(from))
        {
            graph.Add(from, [to]);
        }
        else
        {
            graph[from].Add(to);
        }
        
        if (!graph.ContainsKey(to))
        {
            graph.Add(to, [from]);
        }
        else
        {
            graph[to].Add(from);
        }
    }

    return graph;
}