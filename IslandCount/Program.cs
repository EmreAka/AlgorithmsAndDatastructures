Console.WriteLine("Island Count: 1");

char[,] grid =
{
    { 'W', 'L', 'W', 'W', 'W' },
    { 'W', 'L', 'W', 'W', 'W' },
    { 'W', 'W', 'W', 'L', 'W' },
    { 'W', 'W', 'L', 'L', 'W' },
    { 'L', 'W', 'W', 'L', 'L' },
    { 'L', 'L', 'W', 'W', 'W' },
};

var islandCount = CountIslands(grid);

Console.WriteLine(islandCount);

return;

static int CountIslands(char[,] grid)
{
    var visited = new HashSet<(int, int)>();
    
    var count = 0;

    for (var row = 0; row < grid.GetLength(0); row++)
    {
        for (var column = 0; column < grid.GetLength(1); column++)
        {
            Console.Write($"{grid[row, column]}, ");

            var isIslandExplored = Explore(grid, row, column, visited);

            if (isIslandExplored) count++;
        }
        
        Console.WriteLine();
    }

    return count;
}

static bool Explore(char[,] grid, int row, int column, HashSet<(int, int)> visited)
{
    var rowInBounds = 0 <= row && row < grid.GetLength(0);
    var columnInBounds = 0 <= column && column < grid.GetLength(1);

    if (!rowInBounds || !columnInBounds) return false;

    if (grid[row, column] == 'W') return false;

    if (visited.Contains((row, column))) return false;
    visited.Add((row, column));

    Explore(grid, row - 1, column, visited);
    Explore(grid, row + 1, column, visited);
    Explore(grid, row, column - 1, visited);
    Explore(grid, row, column + 1, visited);
    
    return true;
};