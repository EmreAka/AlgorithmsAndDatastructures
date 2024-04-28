var node = new Node(10);
node.Insert(9);
node.Insert(11);
node.Insert(5);
node.Insert(6);
node.Insert(21);

var result = node.Contains(5);
Console.WriteLine(result);

node.PrintInOrder();

internal record Node(int Data)
{
    private Node? Left { get; set; }
    private Node? Right { get; set; }

    public void Insert(int data)
    {
        if (data <= Data)
        {
            if (Left is null) Left = new(data);
            else Left.Insert(data);
        }
        else
        {
            if (Right is null) Right = new(data);
            else Right.Insert(data);
        }
    }

    public bool Contains(int data)
    {
        if (data == Data) return true;
        
        if (data < Data)
        {
            if (Left is null) return false;
            return Left.Contains(data);
        }

        if (Right is null) return false;
        return Right.Contains(data);
    }

    public void PrintInOrder()
    {
        Left?.PrintInOrder();
        
        Console.WriteLine(Data);
        
        Right?.PrintInOrder();
    }
    
    public void PrintPreOrder()
    {
        Console.WriteLine(Data);
        
        Left?.PrintInOrder();
        
        Right?.PrintInOrder();
    }
    
    public void PrintPostOrder()
    {
        Left?.PrintInOrder();
        
        Right?.PrintInOrder();
        
        Console.WriteLine(Data);
    }
}