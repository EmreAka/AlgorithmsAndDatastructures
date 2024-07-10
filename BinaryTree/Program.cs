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
    public Node? LeftNode { get; set; }
    public Node? RightNode { get; set; }

    public void Insert(int data)
    {
        if (data < Data)
        {
            if (LeftNode is not null)
            {
                LeftNode.Insert(data);
            }
            else
            {
                LeftNode = new(data);
            }
        }
        else
        {
            if (RightNode is not null)
            {
                RightNode.Insert(data);
            }
            else
            {
                RightNode = new(data);
            }
        }
    }

    public bool Contains(int data)
    {
        if (data == Data) return true;

        if (data < Data)
        {
            if (LeftNode is null) return false;
            else return LeftNode.Contains(data);
        }
        else
        {
            if (RightNode is null) return false;
            else return RightNode.Contains(data);
        }
    }

    public void PrintInOrder()
    {
        LeftNode?.PrintInOrder();
        
        Console.WriteLine(Data);
        
        RightNode?.PrintInOrder();
    }
    
    public void PrintPreOrder()
    {
        Console.WriteLine(Data);
        
        LeftNode?.PrintInOrder();
        
        RightNode?.PrintInOrder();
    }
    
    public void PrintPostOrder()
    {
        LeftNode?.PrintInOrder();

        RightNode?.PrintInOrder();
        
        Console.WriteLine(Data);
    }
}