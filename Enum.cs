using System;

public class Account
{
    [Flags]
    public enum Access
    {
        Delete = 1,
        Publish = 1 << 1,
        Submit = 1 << 2,
        Comment = 1 << 3,
        Modify = 1 << 4,
        
        Editor = Delete | Publish | Comment,
        Writer = Submit | Modify, 
        Owner = Editor | Writer
    }
    
    public static void Main(string[] args)
    {       
        Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
    }
}

/* 
using System;

public class Account
{
    [Flags]
    public enum Access
    {
        Delete = 1,
        Publish = 2,
        Submit = 4,
        Comment = 8, 
        Modify = 16,
        
        Editor = 11, 
        Writer = 20,
        Owner = 31
    }
    
    public static void Main(string[] args)
    {       
        Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
    }
}

*/