using System;

public class RoutePlanner
{
    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn, bool[,] mapMatrix)
    {
        bool[,] visited = new bool[mapMatrix.GetLength(0), mapMatrix.GetLength(1)];
        return DFS(fromRow, fromColumn, toRow, toColumn, mapMatrix, visited);
    }

    private static bool DFS(int row, int col, int toRow, int toCol, bool[,] mapMatrix, bool[,] visited)
    {
        if (row < 0 ||
            col < 0 ||
            row >= mapMatrix.GetLength(0) ||
            col >= mapMatrix.GetLength(1) ||
            !mapMatrix[row, col] ||
            visited[row, col])
        {
            return false;
        }

        if (row == toRow && col == toCol)
        {
            return true;
        }

        visited[row, col] = true;

        if (DFS(row + 1, col, toRow, toCol, mapMatrix, visited) ||
            DFS(row - 1, col, toRow, toCol, mapMatrix, visited) ||
            DFS(row, col + 1, toRow, toCol, mapMatrix, visited) ||
            DFS(row, col - 1, toRow, toCol, mapMatrix, visited))
        {
            return true;
        }

        return false;
    }

    public static void Main(string[] args)
    {
        bool[,] mapMatrix = {
            { true, false, false },
            { true, true, false },
            { false, true, true }
        };

        Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
    }
}