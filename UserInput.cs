using System;

public class TextInput {
    public string x = "";
    
    virtual public void Add(char c){
        Console.WriteLine(x += c);
    }
    public string GetValue(){
        return x;
    }
}

public class NumericInput: TextInput {
    override public void Add(char c){
        if(char.IsDigit(c)){
            Console.WriteLine(x += c);
        }
           return;
    }
}

public class UserInput
{
    public static void Main(string[] args)
    {
       TextInput input = new NumericInput();
       input.Add('1');
       input.Add('a');
       input.Add('0');
       Console.WriteLine(input.GetValue());
    }
}