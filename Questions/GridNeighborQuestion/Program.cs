var input = new char[,]
{
    {'9', '4'},
    {'6', '3'},
    {'5', '8'}
};

PrintGrid(GetNeighbors(input));
return;

static char[,] GetNeighbors(char[,] input)
{
    var gridCells = FindNeighbors(input);
    var result = CreateEmptyGrid(input);

    foreach (var gridCell in gridCells)
    {
        var valueIndex = FindValueIndex(result, gridCell.Value);

        foreach (var neighborOfValue in gridCell.Neighbors)
        {
            var neighborIndex = FindNeighborIndex(result, neighborOfValue);

            result[neighborIndex.x, valueIndex.y] = '1';
            result[neighborIndex.y, valueIndex.x] = '1';
        }
    }

    return result;
}

static (long x, long y) FindValueIndex(char[,] grid, char target)
{
    for (var i = 0; i < grid.GetLongLength(0); i++)
    {
        var value = grid[0, i];

        if (value == target)
        {
            return (0, i);
        }
    }

    return (0, 0);
}

static (long x, long y) FindNeighborIndex(char[,] grid, char target)
{
    for (var i = 0; i < grid.GetLongLength(1); i++)
    {
        var value = grid[i, 0];

        if (value == target)
        {
            return (i, 0);
        }
    }

    return (0, 0);
}

static List<GridCell> FindNeighbors(char[,] input)
{
    var length = input.GetLength(0) * input.GetLength(1);
    var result = new List<GridCell>(capacity: length);

    var columns = input.GetLongLength(0);
    var rows = input.GetLongLength(1);

    for (var i = 0; i < input.GetLength(0); i++)
    {
        for (var j = 0; j < input.GetLength(1); j++)
        {
            var value = input[i, j];
            var neighbor = new GridCell(value);

            //right
            if (j < rows - 1)
                neighbor.AddNeighbor(input[i, j + 1]);

            //left
            if (j > 0)
                neighbor.AddNeighbor(input[i, j - 1]);

            //top
            if (i > 0)
                neighbor.AddNeighbor(input[i - 1, j]);

            //bottom
            if (i < columns - 1)
                neighbor.AddNeighbor(input[i + 1, j]);

            result.Add(neighbor);
        }
    }

    return result;
}

static char[,] CreateEmptyGrid(char[,] input)
{
    var length = input.GetLongLength(0) * input.GetLongLength(1) + 1;
    var result = new char[length, length];

    for (var x = 0; x < length; x++)
    {
        for (var y = 0; y < length; y++)
        {
            result[x, y] = '0';
        }
    }

    result[0, 0] = '#';

    var index = 1;
    for (var i = 0; i < input.GetLongLength(0); i++)
    {
        for (var j = 0; j < input.GetLongLength(1); j++)
        {
            var value = input[i, j];

            result[0, index] = value;
            result[index, 0] = value;
            index++;
        }
    }

    return result;
}

static void PrintGrid(char[,] grid)
{
    for (var i = 0; i < grid.GetLength(0); i++)
    {
        for (var j = 0; j < grid.GetLength(1); j++)
        {
            Console.Write(grid[i, j] + " ");
        }
        Console.WriteLine();
    }
}

internal class GridCell
{
    public char Value { get; private set; }
    public List<char> Neighbors { get; init; } = [];

    public GridCell(char value)
    {
        Value = value;
    }

    public void AddNeighbor(char value)
    {
        Neighbors.Add(value);
    }
}