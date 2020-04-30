using System.Collections.Generic;
using System;
using System.Linq;
using ExtensionMethods;
namespace Fixed_project_B
{
    class Program
    {
        static void Main(string[] args)
        {
            string programState = "running";
            string login = "notYetDone";
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            user Niels = new user("Niels", 1234, "0987411@hr.nl", "0610919232", new List<object>());
            cinema Gouda = new cinema("Burgemeester Jamessingel 25, 2803 WV Gouda", 3, "zondag 9:00 - 21:00\nmaandag 9:00 - 21:00\ndinsdag 9:00 - 21:00\nwoensdag 9:00 - 21:00\ndonderdag 9:00 - 21:00\nvrijdag 9:00 - 21:00\nzaterdag 9:00 - 21:00\n");
            Dictionary<string, List<List<string>>> roomsDict = new Dictionary<string, List<List<string>>>();
            string nameOfRoom = "notGiven";
            Dictionary<string, string> users = new Dictionary<string, string>()
            {
                {"Niels", "password"}

            };
            while (programState == "running")
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("login");
                Console.WriteLine("create new user");
                string volgendeMenu = Console.ReadLine();
                if (volgendeMenu == "login")
                {
                    while (login != "succesful")
                    {
                        Console.WriteLine("Enter your username"); 
                        string enteredUsername = Console.ReadLine();
                        Console.WriteLine("Enter your password");
                        string enteredPassword = Console.ReadLine();
                        if (users.ContainsKey(enteredUsername) && users[enteredUsername].Equals(enteredPassword))
                        {
                            login = "succesful";
                            Console.WriteLine("Login succesful");
                        }
                        else
                        {
                            login = "failed";
                            Console.WriteLine("Login failed");
                        }
                    } 
                }
                


                Console.WriteLine("Where do you want to go?\nCinema Info\nRoom Info");

                Console.WriteLine("\n");
                if (volgendeMenu == "make new room")
                {
                    Console.WriteLine("What is the room number?");
                    nameOfRoom = "Room " + Console.ReadLine();
                    Console.WriteLine("How many seats does the room have?");
                    string enteredNumberOfSeats = Console.ReadLine();
                    int numberOfSeats = Int32.Parse(enteredNumberOfSeats);
                    Console.WriteLine("Does the room have 3D?");
                    string roomHas3D = Console.ReadLine();
                    if (roomHas3D == "yes")
                    {
                        bool has3D = true;
                    }
                    else
                    {
                        bool has3D = true;
                    }
                    Console.WriteLine("How many rows does the room have?");
                    string enteredNumberOfRows = Console.ReadLine();
                    int numberOfRows = Int32.Parse(enteredNumberOfRows);
                    Console.WriteLine("How many seats per row does the room have?");
                    string enteredNumberOfSeatsPerRow = Console.ReadLine();
                    int numberOfSeatsPerRow = Int32.Parse(enteredNumberOfSeatsPerRow);
                    roomsDict.Add(nameOfRoom, new List<List<string>>());

                    
                    for (int i = 0; i < numberOfRows; i++)
                    {
                        roomsDict[nameOfRoom].Add(new List<string>());
                        for (int a = 0; a < numberOfSeatsPerRow; a++)
                        {
                            roomsDict[nameOfRoom][i].Add("□");
                        }
                    }
                    Console.WriteLine("Where do you want to go?\nCinema Info\nRoom Info");
                    volgendeMenu = Console.ReadLine();       
                }
                if (volgendeMenu == "cinema info")
                {
                    Console.WriteLine(Gouda.getCinemaInfo());
                }
                if (volgendeMenu == "room info")
                {
                    Console.WriteLine("Which room do you want info about?");
                    string chosenRoom = Console.ReadLine();
                    foreach(List<string> seats in roomsDict[chosenRoom]) {
                        foreach (string square in seats)
                        {
                            Console.Write(square);
                        }
                        Console.Write("\n");
                    
                }
            }
        }
    }
    }
}
