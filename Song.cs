using System;
using System.Collections.Generic;

public class Song
{
    private string name;
    public Song NextSong { get; set; }
 
    public Song(string name)
    {
        this.name = name;
    }
    
    public bool IsRepeatingPlaylist()
    {
        HashSet<string> bank = new HashSet<string>();
        var currentSong = this;
        
        while(true)
        {
            if(currentSong.NextSong == null)
            {
                return false;
            }
            else if(!bank.Contains(currentSong.NextSong.name))
            {
                bank.Add(currentSong.name);
                currentSong = currentSong.NextSong;
            }
            else 
            {
                return true;
            }
        }
    }
    
    public static void Main(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Eye of the tiger");
    
        first.NextSong = second;
        second.NextSong = first;
    
        Console.WriteLine(first.IsRepeatingPlaylist());
    }
}