Dictionary<string, string[]> graph = new()
{
    { "1", ["2"] },
    { "2", ["1"] },
    { "3", [] },
    { "4", ["6"] },
    { "5", ["6"] },
    { "6", ["4", "5", "7", "8"] },
    { "8", ["6"] },
    { "7", ["6"] },
};

var visited = new HashSet<string>();

var count = CountConnectedComponents(graph, visited);

Console.WriteLine(count);

return;

static int CountConnectedComponents(Dictionary<string, string[]> graph, HashSet<string> visited)
{
    var count = 0;
    
    foreach (var node in graph.Keys)
    {
        if (ExploreDfsIterative(graph, node, visited) == true)
        {
            count++;
        }
    }

    return count;
}


static bool ExploreDfs(Dictionary<string, string[]> graph, string source, HashSet<string> visited)
{
    if (visited.Contains(source)) return false;
    visited.Add(source);

    foreach (var neighbor in graph[source])
    {
        ExploreDfs(graph, neighbor, visited);
    }

    return true;
}

static bool ExploreDfsIterative(Dictionary<string, string[]> graph, string source, HashSet<string> visited)
{
    if (visited.Contains(source)) return false;
    
    var stack = new Stack<string>();
    stack.Push(source);

    while (stack.Count > 0)
    {
        var current = stack.Pop();

        if (!visited.Contains(current))
        {
            visited.Add(current);

            foreach (var neighbor in graph[current])
            {
                stack.Push(neighbor);
            }    
        }
    }

    return true;
}