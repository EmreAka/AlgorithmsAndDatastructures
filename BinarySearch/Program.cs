Span<int> sortedList = stackalloc int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Console.WriteLine(BinarySearch(sortedList, 5));
return;

static int BinarySearch(Span<int> source, int target)
{
    var span = new Span(leftIndex: 0, rightIndex: source.Length - 1);

    while (span.LeftIndex <= span.RightIndex)
    {
        var middleValue = source[span.MiddleIndex];

        if (middleValue == target) return span.MiddleIndex;
        if (middleValue < target) span.MoveRight();
        if (middleValue > target) span.MoveLeft();
    }
    
    return -1;
}

internal ref struct Span
{
    public int LeftIndex { get; private set; }
    public int RightIndex { get; private set; }
    public int MiddleIndex { get; private set; }

    public Span(int leftIndex, int rightIndex)
    {
        LeftIndex = leftIndex;
        RightIndex = rightIndex;
        
        CalculateMiddleIndex();
    }

    private void CalculateMiddleIndex() => MiddleIndex = LeftIndex + (RightIndex - LeftIndex) / 2;
    
    public void MoveRight() {
        LeftIndex = MiddleIndex + 1;

        CalculateMiddleIndex();
    }
    
    public void MoveLeft() {
        RightIndex = MiddleIndex - 1;

        CalculateMiddleIndex();
    }
}