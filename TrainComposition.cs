using System;
using System.Linq;
using System.Collections.Generic;

public class TrainComposition
{
    private LinkedList<int> train;
    
    public TrainComposition() 
    {
        this.train = new LinkedList<int>();
    }
    
    public void AttachWagonFromLeft(int wagonId)
    {
        this.train.AddFirst(wagonId);
    }

    public void AttachWagonFromRight(int wagonId)
    {
        this.train.AddLast(wagonId);
    }

    public int DetachWagonFromLeft()
    {
        var node = this.train.First;
        this.train.Remove(node);
        return node.Value;
    }

    public int DetachWagonFromRight()
    {
        var node = this.train.Last;
        this.train.Remove(node);
        return node.Value;
    }

    public static void Main(string[] args)
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        Console.WriteLine(train.DetachWagonFromRight()); // 7 
        Console.WriteLine(train.DetachWagonFromLeft()); // 13
    }
}