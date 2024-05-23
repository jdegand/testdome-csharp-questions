using System;

public class GamePlatform
{
    public static double CalculateFinalSpeed(double initialSpeed, int[] inclinations)
    {
        double speed = initialSpeed;
        
        for (int i = 0; i < inclinations.Length; i++) 
         {
            if(inclinations[i] < 0){
                speed += Math.Abs(inclinations[i]); 
            } else {
                speed -= Math.Abs(inclinations[i]); 
                if(speed <= 0){
                    return 0;
                }
            }  
         }
        return speed;

    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine(CalculateFinalSpeed(60, new int[] { 0, 30, 0, -45, 0 }));
    }
}