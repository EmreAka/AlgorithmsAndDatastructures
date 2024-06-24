var graph = new Dictionary<string, string[]>()
{
    { "f", ["g", "i"] },
    { "g", ["h"] },
    { "h", [] },
    { "i", ["g", "k"] },
    { "j", ["i"] },
    { "k", [] },
};

Console.WriteLine(HasPathDfs(graph, "f", "k")); // True
Console.WriteLine(HasPathDfsIterative(graph, "f", "k")); // True
Console.WriteLine(HasPathBfs(graph, "f", "k")); // True

return;

static bool HasPathDfs(IReadOnlyDictionary<string, string[]> graph, string source, string destination)
{
    if (source == destination)
    {
        return true;
    }

    foreach (var neighbor in graph[source])
    {
        if (HasPathDfs(graph, neighbor, destination))
        {
            return true;
        }
    }

    return false;
}

static bool HasPathDfsIterative(IReadOnlyDictionary<string, string[]> graph, string source, string destination)
{
    var stack = new Stack<String>();
    
    stack.Push(source);

    while (stack.Count > 0)
    {
        var current = stack.Pop();

        if (current == destination)
        {
            return true;
        }
        
        foreach (var neighbor in graph[current])
        {
            stack.Push(neighbor);
        }
    }

    return false;
}

static bool HasPathBfs(IReadOnlyDictionary<string, string[]> graph, string source, string destination)
{
    var queue = new Queue<string>();

    queue.Enqueue(source);

    while (queue.Count > 0)
    {
        var current = queue.Dequeue();
        
        if (current == destination)
        {
            return true;
        }

        foreach (var neighbor in graph[current])
        {
            queue.Enqueue(neighbor);
        }
    }

    return false;
}