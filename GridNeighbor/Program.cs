var input = new char[,]
{
    {'9', '4'},
    {'6', '3'},
    {'5', '8'}
};

Console.WriteLine("Input:");
PrintGrid(input);

var result = GetNeighbors(input);
Console.WriteLine("Neighbors:");
PrintGrid(result);

return;


static char[,] GetNeighbors(char[,] input)
{
    var length = input.GetLongLength(0) * input.GetLongLength(1) + 1;
    var neighbors = FindNeighbors(input);
    var emptyGrid = CreateEmptyGrid(input, length);
    var neighborsGrid = CreateNeighborsGrid(emptyGrid, neighbors);

    return neighborsGrid;
}

static char[,] CreateNeighborsGrid(char[,] input, List<Neighbor> neighbors)
{
    foreach (var neighbor in neighbors)
    {
        (long x, long y) valueIndex = (0, 0);

        for (var i = 0; i < input.GetLongLength(0); i++)
        {
            var value = input[0, i];

            if (value == neighbor.Value)
            {
                valueIndex = (0, i);
                break;
            }
        }

        foreach (var neighborOfValue in neighbor.Neighbors)
        {
            (long x, long y) neighborValueIndex = (0, 0);

            for (var i = 0; i < input.GetLongLength(1); i++)
            {
                var value = input[i, 0];

                if (value == neighborOfValue)
                {
                    neighborValueIndex = (i, 0);
                    break;
                }
            }

            input[neighborValueIndex.x, valueIndex.y] = '1';
        }
    }

    return input;
}

static List<Neighbor> FindNeighbors(char[,] input)
{
    var result = new List<Neighbor>();

    var columns = input.GetLongLength(0);
    var rows = input.GetLongLength(1);

    for (var i = 0; i < input.GetLength(0); i++)
    {
        for (var j = 0; j < input.GetLength(1); j++)
        {
            var value = input[i, j];
            var neighbor = new Neighbor(value);

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

static char[,] CreateEmptyGrid(char[,] input, long length)
{
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

internal class Neighbor
{
    public char Value { get; private set; }
    public List<char> Neighbors { get; private set; } = new();

    public Neighbor(char value)
    {
        Value = value;
    }

    public void AddNeighbor(char value)
    {
        Neighbors.Add(value);
    }
}