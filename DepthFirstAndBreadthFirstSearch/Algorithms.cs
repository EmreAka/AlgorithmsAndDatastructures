namespace DepthFirstAndBreadthFirstSearch;

public static class Algorithms
{
    public static void DepthFirstPrint(Dictionary<string, string[]> graph, string start)
    {
        var stack = new Stack<string>();

        stack.Push(start);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            Console.WriteLine(current);

            foreach (var neighbor in graph[current])
            {
                stack.Push(neighbor);
            }
        }
    }

    public static void DepthFirstRecursivePrint(Dictionary<string, string[]> graph, string source)
    {
        Console.WriteLine(source);

        foreach (var neighbor in graph[source])
        {
            DepthFirstRecursivePrint(graph, neighbor);
        }
    }

    public static void BreadthFirstPrint(Dictionary<string, string[]> graph, string start)
    {
        var queue = new Queue<string>();

        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            Console.WriteLine(current);

            foreach (var neighbor in graph[current])
            {
                queue.Enqueue(neighbor);
            }
        }
    }
}