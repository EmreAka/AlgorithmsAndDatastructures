var edges = new string[][]
{
    ["i", "j"],
    ["k", "i"],
    ["m", "k"],
    ["k", "l"],
    ["o", "n"]
};

/*var graph = new Dictionary<string, string[]>()
{
    { "i", ["j", "k"] },
    { "j", ["i"] },
    { "k", ["i", "m", "l"] },
    { "m", ["k"] },
    { "l", ["k"] },
    { "o", ["n"] },
    { "n", ["o"] }
};*/

var graph = BuildGraph(edges);

var visited = new HashSet<string>();

var hasPath = HasPathDfs(graph, "i", "n", visited); // true

Console.WriteLine(hasPath);

return;

static bool HasPathDfs(Dictionary<string, List<string>> graph, string source, string destination, HashSet<string> visited)
{
    if (source == destination) return true;
    if (visited.Contains(source)) return false;

    visited.Add(source);

    foreach (var neighbor in graph[source])
    {
        var hasPath = HasPathDfs(graph, neighbor, destination, visited);

        if (hasPath == true) return true;
    }
    
    return false;
}

static Dictionary<string, List<string>> BuildGraph(string[][] edges)
{
    var graph = new Dictionary<string, List<string>>();

    foreach (var edge in edges)
    {
        var a = edge[0];
        var b = edge[1];
        
        if (!graph.ContainsKey(a))
        {
            graph.Add(a, [b]);
        }
        else
        {
            graph[a].Add(b);
        }

        if (!graph.ContainsKey(b))
        {
            graph.Add(b, [a]);
        }
        else
        {
            graph[b].Add(a);
        }
    }

    return graph;
}