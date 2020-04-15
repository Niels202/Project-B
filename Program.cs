using System.Collections.Generic;
using System;

namespace Fixed_project_B
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Where do you want to go?\nCinema Info\nRoom Info");
            String volgendeMenu = Console.ReadLine();
            Console.WriteLine("\n");
            if (volgendeMenu == "cinema info")
            {
                Console.WriteLine(Gouda.getCinemaInfo());
            }
            if (volgendeMenu == "room info")
            {
                Console.WriteLine("Which room do you want information about?\n\nRoom A\nRoom B\n");
                string gekozenRoom = Console.ReadLine();
                Console.WriteLine("\n");
                if (gekozenRoom == "room a")
                {
                    Console.WriteLine(roomA.getRoomInfo());
                }
                if (gekozenRoom == "room b")
                {
                    Console.WriteLine(roomB.getRoomInfo());
                }
            }
        }
    }
}
