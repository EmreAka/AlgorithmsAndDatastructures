Dictionary<string, string[]> graph = new()
{
    { "0", ["8", "1", "5"] },
    { "1", ["0"] },
    { "2", ["3", "4"] },
    { "3", ["2", "4"] },
    { "4", ["3", "2"] },
    { "5", ["0", "8"] },
    { "8", ["0", "5"] },
};

var largestComponent = LargestComponent(graph);

Console.WriteLine(largestComponent);

return;

static int LargestComponent(Dictionary<string, string[]> graph)
{
    var largestComponent = 0;

    var visited = new HashSet<string>();

    foreach (var node in graph.Keys)
    {
        var (count, isEndOfIsland) = ExploreDfsIterative(graph, node, visited);

        if (isEndOfIsland && count > largestComponent)
        {
            largestComponent = count;
        }
    }

    return largestComponent;
}

static (int, bool) ExploreDfsIterative(Dictionary<string, string[]> graph, string source, HashSet<string> visited)
{
    var count = 0;
    
    if (visited.Contains(source)) return (count, false);

    var stack = new Stack<string>();
    stack.Push(source);

    while (stack.Count > 0)
    {
        var current = stack.Pop();

        if (!visited.Contains(current))
        {
            visited.Add(current);
            count++;

            foreach (var neighbor in graph[current])
            {
                stack.Push(neighbor);
            }
        }
    }

    return (count, true);
}