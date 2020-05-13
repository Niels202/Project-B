﻿using System.Collections.Generic;
using System;
using System.Linq;
using ExtensionMethods;
namespace Fixed_project_B
{
    class Program
    {
        static void Main(string[] args)
        {
            bool has3D = true;
            string programState = "loginMenu";
            string login = "notYetDone";
            string volgendeMenu = "";
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            user currentUser = new user("","","","");
            cinema Gouda = new cinema("Burgemeester Jamessingel 25, 2803 WV Gouda", 3, "zondag 9:00 - 21:00\nmaandag 9:00 - 21:00\ndinsdag 9:00 - 21:00\nwoensdag 9:00 - 21:00\ndonderdag 9:00 - 21:00\nvrijdag 9:00 - 21:00\nzaterdag 9:00 - 21:00\n");
            Dictionary<string, List<List<string>>> roomsDict = new Dictionary<string, List<List<string>>>();
            string nameOfRoom = "notGiven";
            List<object> Rooms = new List<object>();
            List<user> userList = new List<user>()
            {
                new user("admin", "0987411@hr.nl", "0610919232", "admin")
            };
            Dictionary<string, string> users = new Dictionary<string, string>()
            {
                {"admin", "password"}

            };

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create new user");
            Console.WriteLine("3. Exit");
            volgendeMenu = Console.ReadLine();
            while (true)
            {
                
            
                while (programState == "loginMenu")
                {
                    
                
                    if (volgendeMenu == "1")
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
                                foreach (user user in userList)
                                {
                                    if (user.name == enteredUsername)
                                    {
                                        currentUser = user;
                                    }
                                }
                            }
                            else
                            {
                                login = "failed";
                                Console.WriteLine("Login failed");
                            }
                        } 
                    }
                        
                    else if (volgendeMenu == "2")
                    {
                        Console.WriteLine("What is your name?");
                        string userName = Console.ReadLine();
                        Console.WriteLine("What is your email?");
                        string userEmail = Console.ReadLine();
                        Console.WriteLine("What is your phone number?");
                        string userPhoneNumber = Console.ReadLine();
                        userList.Add(new user(userName, userEmail, userPhoneNumber,"customer"));
                        Console.WriteLine("Enter a password");
                        string userPassword = Console.ReadLine();
                        users.Add(userName, userPassword);
                        Console.WriteLine("What do you want to do?");
                        Console.WriteLine("1. Login");
                        Console.WriteLine("2. Create new user");
                        Console.WriteLine("3. Exit application");
                        volgendeMenu = Console.ReadLine();
                    }    

                    else if (volgendeMenu == "3")
                    {
                        Environment.Exit(0);
                    }
                
                }                

                if (currentUser.role == "customer")
                {
                    
                
                    Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Exit\n Log out");
                    volgendeMenu = Console.ReadLine();
                    Console.WriteLine("\n");
                    
                    while (programState == "running")
                    {

                        
                        if (volgendeMenu == "1")
                        {
                            Console.WriteLine(Gouda.getCinemaInfo());
                            Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Exit Application\n6. Log out");
                            volgendeMenu = Console.ReadLine(); 
                            
                        }
                        else if (volgendeMenu == "2")
                        {
                            
                            foreach (room i in Rooms)
                            {
                                Console.WriteLine(i.getRoomInfo());
                                foreach (KeyValuePair<string, List<List<string>>> currentRoom in roomsDict)
                                {                            
                                    foreach(List<string> seats in roomsDict[currentRoom.Key]) {
                                        foreach (string square in seats)
                                        {
                                            Console.Write(square);
                                        }
                                        Console.Write("\n");
                                    } 
                                }
                            }
                            Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n5. Exit Application\n6. Log out");
                            volgendeMenu = Console.ReadLine();
                        }    
                        else if (volgendeMenu == "3")
                        {
                            Console.WriteLine("What is the room number?");
                            nameOfRoom = "Room " + Console.ReadLine();
                            Console.WriteLine("How many seats does the room have?");
                            string enteredNumberOfSeats = Console.ReadLine();
                            int numberOfSeats = Int32.Parse(enteredNumberOfSeats);
                            Console.WriteLine("Does the room have 3D?\n1. Yes\n2. No");
                            string roomHas3D = Console.ReadLine();
                            if (roomHas3D == "1")
                            {
                                has3D = true;
                            }
                            else
                            {
                                has3D = false;
                            }
                            
                            Console.WriteLine("How many rows does the room have?");
                            string enteredNumberOfRows = Console.ReadLine();
                            int numberOfRows = Int32.Parse(enteredNumberOfRows);
                            Console.WriteLine("How many seats per row does the room have?");
                            string enteredNumberOfSeatsPerRow = Console.ReadLine();
                            int numberOfSeatsPerRow = Int32.Parse(enteredNumberOfSeatsPerRow);
                            roomsDict.Add(nameOfRoom, new List<List<string>>());
                            List<List<string>> newRoomMap = new List<List<string>>();
                            
                            for (int n = 0; n < numberOfRows; n++)
                            {
                                newRoomMap.Add(new List<string>());
                                roomsDict[nameOfRoom].Add(new List<string>());
                                for (int a = 0; a < numberOfSeatsPerRow; a++)
                                {
                                    roomsDict[nameOfRoom][n].Add("□");
                                    newRoomMap[n].Add("□");
                                }
                            }
                            
                            Rooms.Add(new room(numberOfSeats, has3D, nameOfRoom, newRoomMap));
                            Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Exit Application\n6. Log out");
                            volgendeMenu = Console.ReadLine();  
                        }
                        else if (volgendeMenu == "4")
                        {
                            Environment.Exit(0);
                        }    
                        else if (volgendeMenu == "5")
                        {
                            programState = "loginMenu";
                        }
                            
                }       }
                
                else if (currentUser.role == "admin")
                {
                    
                }

                else if (currentUser.role == "manager")
                {
                    
                }

                else if (currentUser.role == "caterer")
                {
                    
                }    

                else if (volgendeMenu == "5")
                {
                    List<string> seatCheckList = new List<string>()
                    {
                        "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
                    };

                    List<string> rowCheckList = new List<string>()
                    {
                        "1", "2", "3", "4", "5", "6"
                    };
                        
                    Console.WriteLine("Please enter the row and seat number you would like to reserve. If you have purchased multiple tickets the seat(s) to the right of the selected seat will automatically be chosen.\n\n");
                    Console.WriteLine("Seat - 12345678910\n", "Row 1 -", roomsDict[nameOfRoom][0], "\n", "Row 2 -", roomsDict[nameOfRoom][1], "\n", "Row 3 -", roomsDict[nameOfRoom][2], "\n", "Row 4 -", roomsDict[nameOfRoom][3], "\n", "Row 5 -", roomsDict[nameOfRoom][4], "\n", "Row 6 -", roomsDict[nameOfRoom][5]);
                    Console.Write("Row: ");
                    string strRow = Console.ReadLine();
                    Console.Write("Seat number: ");
                    string strSeat = Console.ReadLine();

                    if (rowCheckList.Contains(strRow))
                    {
                        if (seatCheckList.Contains(strSeat))
                        {
                            //int roomIndex = roomsDict.Values.ToList().IndexOf(nameOfRoom);
                            int intRow = Convert.ToInt32(strRow);
                            int intSeat = Convert.ToInt32(strSeat);
                            if (roomsDict[nameOfRoom][intRow-1][intSeat-1] != "-")
                            {
                                roomsDict[nameOfRoom][intRow-1][intSeat-1] = "-";
                                Console.WriteLine(roomsDict[nameOfRoom]);
                            }
                            else
                            {
                                Console.WriteLine("Unable to reserve this seat. This seat has already been reserved.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid seat number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid row input.");
                    }
                }


                else if (volgendeMenu == "4")
                {
                    Environment.Exit(0);
                }    
                //----------------------------------------------------------------------
                    
                
                
            }
        }
        
        }

    }



