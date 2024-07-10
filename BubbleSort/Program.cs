
int[] numbers = [5, 3, 1, 66, 100, 31, 25, 16, 67, 985, 342, 423, 35];

var sortedNumbers = BubbleSort(numbers);

foreach (var number in sortedNumbers)
{
    Console.Write(number + ", ");
}

static int[] BubbleSort(int[] source)
{
    /*for (var i = 0; i < source.Length; i++)
    {
        for (var j = 0; j < source.Length - i - 1; j++)
        {
            if (source[j] > source[j + 1])
            {
                (source[j], source[j + 1]) = (source[j + 1], source[j]);
            }
        }
    }
    
    return source;*/

    for (int i = 0; i < source.Length; i++)
    {
        for (int j = 0; j < source.Length - 1 - i; j++)
        {
            if (source[j] > source[j + 1])
            {
                (source[j], source[j + 1]) = (source[j + 1], source[j]);
            }
        }
    }

    return source;
}