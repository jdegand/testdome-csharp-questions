using System;

public class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        int index = Array.BinarySearch(sortedArray, lessThan);
        if (index < 0)
        {
            return ~index; 
            /* If the Array does not contain the specified value, the method returns a negative integer. 
            You can apply the bitwise complement operator (~ in C#, Not in Visual Basic) to the negative result to produce an index.
            */
        }

        return index;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
    }
}

/*
If this method is called with a non-sorted array, the return value can be incorrect and a negative number could be returned, 
even if value is present in array. The BinarySearch method requires the array to be sorted in ascending order.
 */