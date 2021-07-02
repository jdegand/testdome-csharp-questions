/* 25% */

using System;

public class RoutePlanner
{
    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                      bool[,] mapMatrix)
    {
        if(mapMatrix == null)
        {
            return false;
        }
        if(toRow >= mapMatrix.GetLength(0))
        {
            return false;
        }
        
        if(toColumn >= mapMatrix.GetUpperBound(1) + 1)
        {
            return false;
        }
        if(!mapMatrix[toRow, toColumn])
        {
            return false;
        }
        if(fromRow >= mapMatrix.GetLength(0))
        {
            return false;
        }
        if(fromColumn >= mapMatrix.GetUpperBound(1) + 1)
        {
            return false;
        }
        if(!mapMatrix[fromRow, fromColumn])
        {
            return false;
        }
        if(fromRow == toRow && fromColumn == toColumn){
            return true;
        }
        
        bool exists = RouteExists(fromRow + 1, fromColumn, toRow, toColumn, mapMatrix);
        
        if(!exists)
        {
            exists = RouteExists(fromRow, fromColumn + 1, toRow, toColumn, mapMatrix);  
        }
        
        return exists;
    }
    
    public static void Main(string[] args)
    {
        bool[,] mapMatrix = {
            {true, false, false},
            {true, true, false},
            {false, true, true}
        };
        
        Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
    }
}

// have to create a visited array otherwise you will get a stackoverflow