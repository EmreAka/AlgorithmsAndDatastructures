Span<int> sortedList = stackalloc int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Console.WriteLine(BinarySearch(sortedList, 9));
return;

static int BinarySearch(Span<int> source, int target)
{
    var span = new Span(leftIndex: 0, rightIndex: source.Length - 1);

    while (span.LeftIndex <= span.RightIndex)
    {
        var middleValue = source[span.MiddleIndex];

        if (middleValue == target) return span.MiddleIndex;
        if (middleValue > target) span.MoveLeft();
        if (middleValue < target) span.MoveRight();
    }

    return -1;
}

internal ref struct Span
{
    public int LeftIndex { get; set; }
    public int RightIndex { get; set; }
    public int MiddleIndex => LeftIndex + (RightIndex - LeftIndex) / 2;

    public Span(int leftIndex, int rightIndex)
    {
        LeftIndex = leftIndex;
        RightIndex = rightIndex;
    }

    public void MoveLeft() => RightIndex = MiddleIndex - 1;
    public void MoveRight() => LeftIndex = MiddleIndex + 1;
}