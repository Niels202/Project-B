﻿using System.Collections.Generic;
using System;
using System.Linq;
using ExtensionMethods;
using System.IO;

namespace Fixed_project_B
{
    class Program
    {
        static void Main(string[] args)
        {
            // list of variables: their name, cause and where to find them. - boaz
            int x = 0;
            int x2 = 0;
            int x22 = 0;
            int x3 = 0;
            int x4 = 0;
            int x5 = 0;
            int x55 = 0;
            int x6 = 0;
            decimal totalprice = 0;
            int cons_adjust = 0;            // A variable that gets the value that says which consumable from the list to adjust | line 131 |
            int item_amount = 0;
            decimal money = 10;
            string option = "";             // A variable that gets the value that says which option the user wants to select.
            string option2 = "";            // A variable that gets the value that says which option the user wants to select.
            string option3 = "";            // A variable that gets the value that says which option the user wants to select.
            string option4 = "";
            string k2;                      // A variable that gets the value that says the user want to go back | line 201 |
            string loop = "";               // A variable to that stops the while-loop when needed | while-loop line 45  |
            string loop0 = "";              // A variable to that stops the while-loop when needed | while-loop line 69  |
            string loop1 = "";              // A variable to that stops the while-loop when needed | while-loop line 84  |
            string loop2 = "";
            string user = "";               // A variable that gets a value containing the user-type storred into it. | line 51 |
            string filepath = Path.GetFullPath("consumablefile.TXT");
            List<Movie> movies = new List<Movie>();
            
            // list of variables: their name, cause and where to find them.
            string program = "running";
            string userAge = "";
            bool has3D = true;
            string programState = "loginMenu";
            string login = "notYetDone";
            string volgendeMenu = "";
            string userMenu = "";
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            user currentUser = new user("", "", "", "", "", 0, new List<string>());
            admin currentAdmin = new admin("", "", "", "", "", 0, new List<string>());
            customer currentCustomer = new customer("", "", "", "", "", "", 0, new List<string>());
            caterer currentCaterer = new caterer("", "", "", "", "", 0, new List<string>());
            manager currentManager = new manager("", "", "", "", "", 0, new List<string>());

            //Tests
            
            List<List<string>> testRoomMap = new List<List<string>>()
            {
                new List<string>(){"1", "2", "3", "4", "5"}, new List<string>(){"1", "2", "3", "4", "5"}, new List<string>(){"1", "2", "3", "4", "5"}, new List<string>(){"1", "2", "3", "4", "5"}
            };
            room testRoom = new room(40, true, "Room 0", 0, testRoomMap);
            Movie Shrek = new Movie("Shrek", "Movie description", "Movie Genre", "Minimal age");
            timeSlot testSlot = new timeSlot(Shrek, testRoom);
            Dictionary<string, timeSlot> testDate = new Dictionary<string, timeSlot>()
            {
                {"09:00", testSlot}
            };
            Dictionary<string, Dictionary<string, timeSlot>> timeSlotDates = new Dictionary<string, Dictionary<string, timeSlot>>()
            {
                {"01-01-2000", testDate}
            };

            
            cinema Gouda = new cinema("Burgemeester Jamessingel 25, 2803 WV Gouda", 3, "zondag 9:00 - 21:00\nmaandag 9:00 - 21:00\ndinsdag 9:00 - 21:00\nwoensdag 9:00 - 21:00\ndonderdag 9:00 - 21:00\nvrijdag 9:00 - 21:00\nzaterdag 9:00 - 21:00\n");
            Dictionary<string, List<List<string>>> roomsDict = new Dictionary<string, List<List<string>>>();
            string nameOfRoom = "notGiven";
            string NameOfMovie = "notGiven";
            string selectedMovieDate = "";
            string selectedMovieTime = "";
            List<string> movieCheckList = new List<string>();
            List<room> Rooms = new List<room>();

            List<admin> adminList = new List<admin>()
            {

            };
            List<customer> customerList = new List<customer>()
            {

            };
            List<manager> managerList = new List<manager>()
            {

            };
            List<caterer> catererList = new List<caterer>()
            {

            };
            Dictionary<string, string> users = new Dictionary<string, string>()
            {

            };
            List<Consumable> ConsumableList = new List<Consumable>()
            {

            };
            List<string> cons_to_string = new List<string>()
            {

            };
            List<int> xList = new List<int>()
            {

            };

            timeSlot time0900 = new timeSlot(null, null);
            timeSlot time1100 = new timeSlot(null, null);
            timeSlot time1300 = new timeSlot(null, null);
            timeSlot time1500 = new timeSlot(null, null);
            timeSlot time1700 = new timeSlot(null, null);
            timeSlot time1900 = new timeSlot(null, null);
            timeSlot time2100 = new timeSlot(null, null);

            Dictionary<string, timeSlot> timeSlotsList = new Dictionary<string, timeSlot>()
            {
                {"09:00", time0900},
                {"11:00", time1100},
                {"13:00" , time1300},
                {"15:00", time1500},
                {"19:00", time1900},
                {"21:00", time2100}
            };
            
            string adminFile = Path.GetFullPath("adminFile.txt");
            string customerFile = Path.GetFullPath("customerFile.txt");
            string managerFile = Path.GetFullPath("managerFile.txt");
            string catererFile = Path.GetFullPath("catererFile.txt");

            List<string> adminFileLines = File.ReadAllLines(adminFile).ToList();
            foreach (var line in adminFileLines)
            {
                string[] entries = line.Split(',');

                admin newAdmin = new admin("", "", "", "", "", 100000, new List<string>());
                newAdmin.name = entries[0];
                newAdmin.email = entries[1];
                newAdmin.phoneNumber = entries[2];
                newAdmin.role = entries[3];
                newAdmin.password = entries[4];


                adminList.Add(newAdmin);
                users.Add(newAdmin.name, newAdmin.role);
            }
            List<string> customerFileLines = File.ReadAllLines(customerFile).ToList();
            foreach (var line in customerFileLines)
            {
                string[] entries = line.Split(',');

                customer newCustomer = new customer("", "", "", "", "", "", 0, new List<string>());
                newCustomer.name = entries[0];
                newCustomer.email = entries[1];
                newCustomer.phoneNumber = entries[2];
                newCustomer.role = entries[3];
                newCustomer.password = entries[4];
                newCustomer.balance = Int32.Parse(entries[5]);


                customerList.Add(newCustomer);
                users.Add(newCustomer.name, newCustomer.role);
            }
            List<string> catererFileLines = File.ReadAllLines(catererFile).ToList();
            foreach (var line in catererFileLines)
            {
                string[] entries = line.Split(',');

                caterer newCaterer = new caterer("", "", "", "", "", 0, new List<string>());
                newCaterer.name = entries[0];
                newCaterer.email = entries[1];
                newCaterer.phoneNumber = entries[2];
                newCaterer.role = entries[3];
                newCaterer.password = entries[4];
                newCaterer.balance = Int32.Parse(entries[5]);


                catererList.Add(newCaterer);
                users.Add(newCaterer.name, newCaterer.role);
            }
            List<string> managerFileLines = File.ReadAllLines(managerFile).ToList();
            foreach (var line in managerFileLines)
            {
                string[] entries = line.Split(',');

                manager newManager = new manager("", "", "", "", "", 0, new List<string>());
                newManager.name = entries[0];
                newManager.email = entries[1];
                newManager.phoneNumber = entries[2];
                newManager.role = entries[3];
                newManager.password = entries[4];
                newManager.balance = Int32.Parse(entries[5]);


                managerList.Add(newManager);
                users.Add(newManager.name, newManager.role);
            }


            while (program == "running")
            {
                while (programState == "loginMenu")
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Create new user");
                    Console.WriteLine("3. Exit");
                    volgendeMenu = Console.ReadLine();
                    if (volgendeMenu == "1")
                    {
                        login = "notYetDone";
                        while (login != "succesful" & login != "failed")
                        {
                            Console.WriteLine("Enter your username");
                            string enteredUsername = Console.ReadLine();
                            Console.WriteLine("Enter your password");
                            string enteredPassword = Console.ReadLine();
                            if (users.ContainsKey(enteredUsername) != true)
                            {
                                Console.WriteLine("That username and password combination does not exist");
                                login = "succesful";
                            }
                            else if (users[enteredUsername] == "admin")
                            {
                                foreach (admin admin in adminList)
                                {
                                    if (admin.name == enteredUsername)
                                    {
                                        currentAdmin = admin;
                                    }
                                }
                                if (currentAdmin.password == enteredPassword)
                                {
                                    login = "succesful";
                                    userMenu = "admin";
                                    Console.WriteLine("Login succesful");
                                    programState = "running";
                                }
                                else
                                {
                                    login = "failed";
                                    Console.WriteLine("Login failed");
                                }
                            }
                            else if (users[enteredUsername] == "customer")
                            {
                                foreach (customer customer in customerList)
                                {
                                    if (customer.name == enteredUsername)
                                    {
                                        currentCustomer = customer;
                                    }
                                }
                                if (currentCustomer.password == enteredPassword)
                                {
                                    login = "succesful";
                                    userMenu = "customer";
                                    Console.WriteLine("Login succesful");
                                    programState = "running";
                                }
                                else
                                {
                                    login = "failed";
                                    Console.WriteLine("Login failed");
                                }
                            }
                            else if (users[enteredUsername] == "caterer")
                            {
                                foreach (caterer caterer in catererList)
                                {
                                    if (caterer.name == enteredUsername)
                                    {
                                        currentCaterer = caterer;
                                    }
                                }
                                if (currentCaterer.password == enteredPassword)
                                {
                                    login = "succesful";
                                    userMenu = "caterer";
                                    Console.WriteLine("Login succesful");
                                    programState = "running";
                                }
                                else
                                {
                                    login = "failed";
                                    Console.WriteLine("Login failed");
                                }
                            }
                            else if (users[enteredUsername] == "manager")
                            {
                                foreach (manager manager in managerList)
                                {
                                    if (manager.name == enteredUsername)
                                    {
                                        currentManager = manager;
                                    }
                                }
                                if (currentManager.password == enteredPassword)
                                {
                                    login = "succesful";
                                    userMenu = "manager";
                                    Console.WriteLine("Login succesful");
                                    programState = "running";
                                }
                                else
                                {
                                    login = "failed";
                                    Console.WriteLine("Login failed");
                                }
                            }
                        }
                    }

                    else if (volgendeMenu == "2")
                    {
                        Console.WriteLine("\nWhat is your name?");
                        string userName = Console.ReadLine();
                        Console.WriteLine("What is your age?");
                        userAge = Console.ReadLine();
                        Console.WriteLine("\nWhat is your email?");
                        string userEmail = Console.ReadLine();
                        Console.WriteLine("\nWhat is your phone number?");
                        string userPhoneNumber = Console.ReadLine();
                        Console.WriteLine("\nEnter a password");
                        string userPassword = Console.ReadLine();
                        customerList.Add(new customer(userName, userEmail, userPhoneNumber, "customer", userPassword, userAge, 0, new List<string>()));
                        users.Add(userName, "customer");
                        Console.WriteLine("\nWhat do you want to do?");
                        Console.WriteLine("\n1. Login");
                        Console.WriteLine("2. Create new user");
                        Console.WriteLine("3. Exit application");
                        volgendeMenu = Console.ReadLine();
                    }

                    else if (volgendeMenu == "3")
                    {
                        program = "shutdown";
                        programState = "shutdown";
                    }


                }

                while (programState == "running")
                {

                    if (userMenu == "admin")
                    {

                        Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                        volgendeMenu = Console.ReadLine();
                        Console.WriteLine("\n");


                        while (programState == "running")
                        {


                            if (volgendeMenu == "2")
                            {
                                Console.WriteLine(Gouda.getCinemaInfo());
                                Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                volgendeMenu = Console.ReadLine();

                            }

                            else if (volgendeMenu == "3")
                            {

                                foreach (room i in Rooms)
                                {
                                    Console.WriteLine(i.getRoomInfo());
                                    foreach (KeyValuePair<string, List<List<string>>> currentRoom in roomsDict)
                                    {
                                        foreach (List<string> seats in roomsDict[currentRoom.Key])
                                        {
                                            foreach (string square in seats)
                                            {
                                                Console.Write(square);
                                                Console.Write(" ");
                                            }
                                            Console.Write("\n");
                                        }
                                    }
                                }
                                Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                volgendeMenu = Console.ReadLine();
                            }
                            else if (volgendeMenu == "10")
                            {
                                program = "shutdown";
                                programState = "shutdown";
                            }
                            else if (volgendeMenu == "6")
                            {
                                List<string> seatCheckList = new List<string>()
                                {
                                    "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
                                };

                                List<string> rowCheckList = new List<string>()
                                {
                                    "1", "2", "3", "4", "5", "6"
                                };
                                //Overzicht van alle films
                                Console.WriteLine("Overview of available movies: \n\n");
                                foreach (var o in timeSlotDates)
                                {
                                    foreach (var q in timeSlotsList)
                                    {
                                        Console.WriteLine(q.Value.movie.movieName);
                                        movieCheckList.Add(q.Value.movie.movieName);
                                    }
                                }
                                Console.WriteLine("\nInput the name of the movie you would like to reserve tickets as the following format: \n\"Shrek\"\n");
                                string nameOfMovie = Console.ReadLine();
                                if (movieCheckList.Contains(nameOfMovie))
                                {
                                    foreach (var p in timeSlotDates)
                                    {
                                        Console.WriteLine(p.Key);
                                        foreach (var l in timeSlotsList)
                                        {
                                            if (l.Value.movie.movieName == nameOfMovie)
                                            {
                                                Console.WriteLine(l.Key);
                                            }
                                        }
                                    }
                                    //Clears the moviechecklist for reuse
                                    movieCheckList.Clear();
                                    Console.WriteLine("Input the date you would like to see the movie at using the following format: 01-01-2020\n");
                                    selectedMovieDate = Console.ReadLine();
                                    Console.WriteLine("Input the time you would like to see " + nameOfMovie + " on " + selectedMovieDate + " at using the following format: 09:00\n");
                                    selectedMovieTime = Console.ReadLine();
                                    Console.WriteLine("Available seats: \n");
                                    foreach (var k in timeSlotDates)
                                    {
                                        if (k.Key == selectedMovieDate)
                                        {
                                            foreach (var m in k.Value)
                                            {
                                                if (m.Key == selectedMovieTime)
                                                {
                                                    int rowCounter = 1;
                                                    int mapTeller = 0;
                                                    foreach (var i in m.Value.Room.seatsMap)
                                                    {
                                                        Console.Write("Row " + rowCounter + ". ");
                                                        foreach (var e in i)
                                                        {
                                                            Console.Write(e);
                                                            Console.Write(" ");
                                                        }
                                                        rowCounter++;
                                                        mapTeller++;
                                                        Console.Write("\n");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    Console.WriteLine("\nPlease enter the row and seat number you would like to reserve.");
                                    Console.Write("Row: ");
                                    string strRow = Console.ReadLine();
                                    Console.Write("Seat number: ");
                                    string strSeat = Console.ReadLine();
                                    Console.WriteLine("\n");

                                }
                                else
                                {
                                    Console.WriteLine("Invalid movie name, returning to main menu.\n");
                                    Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                    volgendeMenu = Console.ReadLine();
                                }
                                //Room map
                                Console.WriteLine("\n");
                                //roomsDict[roomName][rij][stoel]
                                //int rowCounter = 1;
                                //int mapTeller = 0;
                                //if (roomsDict.ContainsKey(nameOfRoom))
                                //{
                                //    int dictCount = roomsDict[nameOfRoom].Count;
                                //    foreach (var i in roomsDict[nameOfRoom])
                                //    {
                                //        Console.Write("Row " + rowCounter + " - ");
                                //        foreach (var e in roomsDict[nameOfRoom][mapTeller])
                                //        {
                                //            Console.Write(e);
                                //            Console.Write(" ");
                                //        }
                                //        rowCounter++;
                                //        mapTeller++;
                                //        Console.Write("\n");
                                //    }
                                //    Console.WriteLine("\nPlease enter the row and seat number you would like to reserve.");
                                //    Console.Write("Row: ");
                                //    string strRow = Console.ReadLine();
                                //    Console.Write("Seat number: ");
                                //    string strSeat = Console.ReadLine();
                                //    Console.WriteLine("\n");

                                //    if (rowCheckList.Contains(strRow))
                                //    {
                                //        if (seatCheckList.Contains(strSeat))
                                //        {
                                //            int intRow = Convert.ToInt32(strRow);
                                //            int intSeat = Convert.ToInt32(strSeat);
                                //            if (roomsDict[nameOfRoom][intRow - 1][intSeat - 1] != "-")
                                //            {
                                //                //roomsDict[roomName][rij][stoel]
                                //                roomsDict[nameOfRoom][intRow - 1][intSeat - 1] = "-";
                                //                rowCounter = 1;
                                //                mapTeller = 0;
                                //                foreach (var i in roomsDict[nameOfRoom])
                                //                {
                                //                    Console.Write("Row " + rowCounter + ". ");
                                //                    foreach (var e in roomsDict[nameOfRoom][mapTeller])
                                //                    {
                                //                        Console.Write(e);
                                //                        Console.Write(" ");
                                //                    }
                                //                    rowCounter++;
                                //                    mapTeller++;
                                //                    Console.Write("\n");
                                //                }
                                //                Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                //                volgendeMenu = Console.ReadLine();
                                //            }
                                //            else
                                //            {
                                //                Console.WriteLine("Unable to reserve this seat. This seat has already been reserved.");
                                //                Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                //                volgendeMenu = Console.ReadLine();
                                //            }
                                //        }
                                //        else
                                //        {
                                //            Console.WriteLine("\nInvalid seat number.");
                                //            Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                //            volgendeMenu = Console.ReadLine();
                                //        }
                                //    }
                                //    else
                                //    {
                                //        Console.WriteLine("\nInvalid row input.");
                                //        Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                //        volgendeMenu = Console.ReadLine();
                                //    }
                                //}
                                //else
                                //{
                                //    Console.WriteLine("\nInvalid room name, check if you have used the right format and make sure the room exists.");
                                //    Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                //    volgendeMenu = Console.ReadLine();
                               // }
                            }
                        
                            else if (volgendeMenu == "4")
                            {
                                Console.WriteLine("\nWhat is the room number?");
                                nameOfRoom = "Room " + Console.ReadLine();
                                //Console.WriteLine("\nHow many seats does the room have?");/////////
                                //string enteredNumberOfSeats = Console.ReadLine();
                                //int numberOfSeats = Int32.Parse(enteredNumberOfSeats);
                                Console.WriteLine("\nDoes the room have 3D?\n1. Yes\n2. No");
                                string roomHas3D = Console.ReadLine();
                                if (roomHas3D == "1")
                                {
                                    has3D = true;
                                }
                                else
                                {
                                    has3D = false;
                                }

                                Console.WriteLine("\nHow many rows does the room have?");
                                string enteredNumberOfRows = Console.ReadLine();
                                int numberOfRows = Int32.Parse(enteredNumberOfRows);
                                Console.WriteLine("\nHow many seats per row does the room have?");
                                string enteredNumberOfSeatsPerRow = Console.ReadLine();
                                int numberOfSeatsPerRow = Int32.Parse(enteredNumberOfSeatsPerRow);
                                int numberOfSeats = numberOfRows * numberOfSeatsPerRow;
                                Console.WriteLine("How much does a ticket for this room cost?"); //Price per ticket 
                                string strTicketPrice = Console.ReadLine();
                                int intTicketPrice = Int32.Parse(strTicketPrice);
                                roomsDict.Add(nameOfRoom, new List<List<string>>());
                                List<List<string>> newRoomMap = new List<List<string>>();

                                for (int n = 0; n < numberOfRows; n++)
                                {
                                    newRoomMap.Add(new List<string>());
                                    roomsDict[nameOfRoom].Add(new List<string>());
                                    for (int a = 0; a < numberOfSeatsPerRow; a++)
                                    {
                                        int intA = a + 1;
                                        string stringA = intA.ToString();
                                        roomsDict[nameOfRoom][n].Add(stringA);
                                        newRoomMap[n].Add(stringA);
                                    }
                                }

                                Rooms.Add(new room(numberOfSeats, has3D, nameOfRoom, intTicketPrice, newRoomMap));
                                Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                volgendeMenu = Console.ReadLine();
                            }


                            else if (volgendeMenu == "9")
                            {
                                programState = "loginMenu";
                            }
                            else if (volgendeMenu == "1")
                            {
                                Console.WriteLine("What is the users role?");
                                string userRole = Console.ReadLine();
                                if (userRole == "customer")
                                {
                                    Console.WriteLine("What is the users age?");
                                    userAge = Console.ReadLine();
                                }
                                Console.WriteLine("What is the users name?");
                                string userName = Console.ReadLine();
                                Console.WriteLine("What is the users email?");
                                string userEmail = Console.ReadLine();
                                Console.WriteLine("What is the users phone number?");
                                string userPhoneNumber = Console.ReadLine();
                                Console.WriteLine("Enter a password for the user");
                                string userPassword = Console.ReadLine();
                                if (userRole == "admin")
                                {
                                    adminList.Add(new admin(userName, userEmail, userPhoneNumber, userRole, userPassword, 10000, new List<string>()));
                                }
                                else if (userRole == "customer")
                                {
                                    customerList.Add(new customer(userName, userEmail, userPhoneNumber, userRole, userPassword, userAge, 0, new List<string>()));
                                }
                                else if (userRole == "caterer")
                                {
                                    catererList.Add(new caterer(userName, userEmail, userPhoneNumber, userRole, userPassword, 0, new List<string>()));
                                }
                                else if (userRole == "manager")
                                {
                                    managerList.Add(new manager(userName, userEmail, userPhoneNumber, userRole, userPassword, 0, new List<string>()));
                                }

                                users.Add(userName, userRole);
                                Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                volgendeMenu = Console.ReadLine();
                            }
                            else if (volgendeMenu == "5")
                            {
                                ConsumableList = new List<Consumable>();
                                List<string> lines = File.ReadAllLines(filepath).ToList();

                                foreach (var line in lines)
                                {
                                    string[] entries = line.Split('.');

                                    Consumable newconsumable = new Consumable();

                                    newconsumable.name = entries[0];
                                    newconsumable.amount = int.Parse(entries[1]);
                                    newconsumable.price = decimal.Parse(entries[2]);
                                    newconsumable.num = int.Parse(entries[3]);

                                    ConsumableList.Add(newconsumable);
                                }

                                Console.WriteLine("welcome admin! \n Press enter if you want a overview of all the consumables in stock.");
                                Console.Read();

                                foreach (Consumable i in ConsumableList)
                                {
                                    Console.WriteLine(i.getData());
                                }

                                Console.WriteLine("\n Type anything to go back.");
                                Console.Read();

                                Console.WriteLine("Where do you want to go?\n1. Create new user\n2. Cinema Info\n3. Room Info\n4. Make New Room\n5. Get consumable overview\n6. Make reservation\n7. Configure new movie\n8. Assign movie to timeslot\n9. Log out\n10. Exit application");
                                volgendeMenu = Console.ReadLine();
                            }
                        }
                    }



                    else if (userMenu == "customer")
                    {
                        
                        ConsumableList = new List<Consumable>();
                        List<string> lines = File.ReadAllLines(filepath).ToList();

                        foreach (var line in lines)
                        {
                            string[] entries = line.Split('.');

                            Consumable newconsumable = new Consumable();

                            newconsumable.name = entries[0];
                            newconsumable.amount = int.Parse(entries[1]);
                            newconsumable.price = decimal.Parse(entries[2]);
                            newconsumable.num = int.Parse(entries[3]);

                            ConsumableList.Add(newconsumable);
                        }
                        List<Consumable> ConsumableList_change = ConsumableList.Select(x => x.Copy()).ToList();
                        List<Consumable> ConsumableList_cart = ConsumableList.Select(x => x.Copy()).ToList();

                        foreach (Consumable i in ConsumableList_cart)
                        {
                            i.amount = 0;
                        }

                        while (programState == "running")
                        {
                            x2 = 0;
                            Console.Clear();
                            Console.WriteLine("Welcome customer! \n Choose the product(number) you want to put in your cart or one of the other options.");
                            Console.WriteLine("Items in your cart: " + item_amount + " " + "| Te betalen: " + totalprice + " | " + "Money in account: " + money);
                            Console.WriteLine("");

                            foreach (Consumable i in ConsumableList_change)
                            {
                                Console.WriteLine("" + x2 + ". " + i.customerproducts());
                                x2 += 1;
                                x22 = x2;
                            }
                            x2 = 0;

                            Console.WriteLine(x22 + ". adjust cart");
                            Console.WriteLine((x22 + 1) + ". proceed to pay");
                            Console.WriteLine((x22 + 2) + ". Log out.");
                            Console.WriteLine((x22 + 3) + ". Exit Program.");

                            x3 = Consumable.o_try_parse("Select your option number: ", (x22 + 3));

                            if (x3 == x22) //ajust cart option.
                            {
                                while (loop2 != "stop")
                                {
                                    List<int> og_listposition = new List<int>();
                                    x2 = 0;
                                    x55 = 0;

                                    Console.WriteLine("The products in your cart: \nSelect the number of the product you would like to adjust the amount of. ");

                                    foreach (Consumable i in ConsumableList_cart)
                                    {
                                        if (i.amount > 0)
                                        {
                                            Console.WriteLine(x55 + ". " + i.name + ": " + i.amount);
                                            x55 += 1;
                                            og_listposition.Add(x2); // because of this list you can select the right object from the consumablelist without showing all the product that are not in your cart.
                                        }
                                        x2 += 1;
                                    }
                                    Console.WriteLine(x55 + ". back out");

                                    x5 = Consumable.o_try_parse("select your option number: ", x55);

                                    if (x5 == x55) // back-out in ajust cart optie.
                                    {
                                        loop2 = "stop";
                                    }

                                    else
                                    {
                                        x6 = Consumable.o_try_parse("name: " + ConsumableList[og_listposition[x5]].name + " | current amount in your cart: " + ConsumableList_cart[og_listposition[x5]].amount + "." + "\n New amount: ", ConsumableList[og_listposition[x5]].amount);

                                        totalprice = totalprice - (ConsumableList_change[og_listposition[x5]].price * ConsumableList_cart[og_listposition[x5]].amount); // haalt het hele bedrag van het product van de totaalprice af.
                                        totalprice = totalprice + (ConsumableList_change[og_listposition[x5]].price * x6);                                              // doet het bedrag van het product (new amount) bij de totaalprice.

                                        // zet alle variable terug naar een staat waar er geen producten in de cart zijn gedaan.
                                        ConsumableList_change[og_listposition[x5]].amount = (ConsumableList_change[og_listposition[x5]].amount + ConsumableList_cart[og_listposition[x5]].amount);
                                        item_amount = item_amount - ConsumableList_cart[og_listposition[x5]].amount;

                                        // past de variabelen aan naar de nieuwe amount.
                                        ConsumableList_cart[og_listposition[x5]].amount = x6;
                                        ConsumableList_change[og_listposition[x5]].amount = ConsumableList_change[og_listposition[x5]].amount - x6;
                                        item_amount = item_amount + x6;
                                    }
                                }
                                loop2 = "";
                            }

                            else if (x3 == (x22 + 1)) // pay option
                            {
                                if (money >= totalprice)
                                {
                                    while (loop0 != "stop")
                                    {
                                        Console.WriteLine("Are you sure you want to pay? \n Press enter to proceed, type back if you want to go back.");
                                        option4 = Console.ReadLine();

                                        if (option4 == "back")
                                        {
                                            loop0 = "stop";
                                        }

                                        else if (option4 == "")
                                        {
                                            money = money - totalprice;
                                            ConsumableList = ConsumableList_change.Select(x => x.Copy()).ToList();
                                            totalprice = 0;
                                            item_amount = 0;

                                            cons_to_string = new List<string>();

                                            foreach (var Consumable in ConsumableList)
                                            {
                                                cons_to_string.Add($"{ Consumable.name }.{ Consumable.amount }.{ Consumable.price }.{ Consumable.num }");
                                            }

                                            File.WriteAllLines(filepath, cons_to_string);

                                            Console.WriteLine("Thank you for your purchase.");
                                            loop0 = "stop";
                                            Console.Read();
                                        }

                                        else
                                        {
                                            Console.WriteLine("Wrong input, please try again.");
                                        }
                                    }
                                    loop0 = "";
                                }

                                else
                                {
                                    Console.WriteLine("You do not have enough money for this purchase, please change the amount that is in your cart.");
                                    Console.Read();
                                }
                            }

                            else if (x3 == (x22 + 2)) // logout optie
                            {
                                programState = "loginMenu";
                                totalprice = 0;
                                item_amount = 0;
                            }

                            else if (x3 == (x22 + 3))
                            {
                                program = "shutdown";
                                programState = "shutdown";
                            }

                            else
                            {
                                x4 = Consumable.i_try_parse("amount of " + ConsumableList[x3].name + ": ");

                                item_amount += x4;                                                                  // item_amount is the amount in cart
                                ConsumableList_change[x3].amount = (ConsumableList_change[x3].amount - x4);
                                ConsumableList_cart[x3].amount = (ConsumableList_cart[x3].amount + x4);
                                totalprice = totalprice + ConsumableList_change[x3].price * x4;
                            }
                        }
                        
                    }

                    else if (userMenu == "manager")
                    {
                        
                        while (programState == "running")
                        {

                            if (volgendeMenu == "1")
                            {
                                Console.WriteLine("What is the movie name?");
                                string movieName = Console.ReadLine();
                                Console.WriteLine("What is the movie description?");
                                string movieDescription = Console.ReadLine();
                                Console.WriteLine("What is the movie genre?");
                                string movieGenre = Console.ReadLine();
                                Console.WriteLine("What is the minimal age?");
                                string minimalAge = Console.ReadLine();
                                if (movies.Any(movie => movie.movieName == movieName))
                                {
                                    Console.Write("That movie already exists");
                                }
                                else
                                {
                                    movies.Add(new Movie(movieName, movieDescription, movieGenre, minimalAge));
                                }

                            }
                            else if (volgendeMenu == "2")
                            {
                                Console.WriteLine("What movie will play?");
                                string chosenMovie = Console.ReadLine();
                                Console.WriteLine("On what date does the movie play?");
                                string movieDate = Console.ReadLine();
                                Console.WriteLine("What is the timeslot of the movie?");
                                string movieTimeSlot = Console.ReadLine();
                                Console.WriteLine("In what room does the movie play?");
                                string chosenRoom = Console.ReadLine();
                                foreach (var date in timeSlotDates)
                                {
                                    if (date.Key == movieTimeSlot)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        timeSlotDates.Add(movieDate, new Dictionary<string, timeSlot>(timeSlotsList));
                                    }
                                }
                                foreach (var listDate in timeSlotDates)
                                {
                                    if (listDate.Key == movieDate)
                                    {
                                        foreach (var timeSlot in timeSlotsList)
                                        {
                                            if (timeSlot.Key == movieTimeSlot)
                                            {
                                                foreach (var listMovie in movies)
                                                {
                                                    if (listMovie.movieName == chosenMovie)
                                                    {
                                                        timeSlot.Value.movie = listMovie;
                                                    }          
                                                }
                                                foreach (var listRoom in Rooms)
                                                {
                                                    if (listRoom.roomName == chosenRoom)
                                                    {
                                                        timeSlot.Value.Room = listRoom;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else if (userMenu == "caterer")
                    {

                        ConsumableList = new List<Consumable>();
                        List<string> lines = File.ReadAllLines(filepath).ToList();

                        foreach (var line in lines)
                        {
                            string[] entries = line.Split('.');

                            Consumable newconsumable = new Consumable();

                            newconsumable.name = entries[0];
                            newconsumable.amount = int.Parse(entries[1]);
                            newconsumable.price = decimal.Parse(entries[2]);
                            newconsumable.num = int.Parse(entries[3]);

                            ConsumableList.Add(newconsumable);
                        }
                        

                        while (programState == "running")
                        {
                            option2 = "";
                            option3 = "";

                            Console.Clear();
                            Console.WriteLine("caterer menu \n 1. Add consumables \n 2. adjust consumables \n 3. show consumables \n 4. Safe \n 5. Log out \n 6. Exit program");
                            Console.WriteLine("choose option: "); option = Console.ReadLine();

                            if (option == "1")
                            {
                                while (option2 != "back")
                                {
                                    option2 = "";
                                    Consumable newconsumable = new Consumable();
                                    Console.WriteLine("Creating new consumable... \n ");

                                    Console.WriteLine("Name of new consumable: ");
                                    newconsumable.name = Console.ReadLine();

                                    newconsumable.amount = Consumable.i_try_parse("Amount in stock of new consumable: ");
                                    newconsumable.price = Consumable.m_try_parse("The price of the new consumable: ");

                                    newconsumable.num += x;
                                    x = x + 1;

                                    ConsumableList.Add(newconsumable);

                                    Console.WriteLine("Do you want to add / create another consumable (press enter or type anything) or back out to the main menu and safe? (type back) ");
                                    option2 = Console.ReadLine();
                                }
                            }

                            else if (option == "2")
                            {
                                Console.WriteLine("if you want to adjust / change a consumable, press enter. If you want to go back to the main menu, type back");
                                option3 = Console.ReadLine();

                                while (option3 != "back")
                                {
                                    cons_adjust = Consumable.i_try_parse($"Which consumable do you want to adjust? Type in the number of the consumable. \nYou can find the number of the consumable with option 3 of the main menu called show consumables.");

                                    if (cons_adjust <= x && cons_adjust >= 0)
                                    {
                                        Console.WriteLine("Unajusted consumable: ");
                                        Console.WriteLine(ConsumableList[cons_adjust].getData());

                                        Console.WriteLine("Change what you want to change. Fill in the old value for the things you want to stay the same. \n");

                                        Console.WriteLine("Name: ");
                                        ConsumableList[cons_adjust].name = Console.ReadLine();

                                        ConsumableList[cons_adjust].amount = Consumable.i_try_parse("Amount in stock: ");
                                        ConsumableList[cons_adjust].price = Consumable.m_try_parse("Price: ");

                                        Console.WriteLine("\n Do you want to adjust another consumable? \n If you want to adjust another consumable, press enter. If you want to go back to the main menu, type back");
                                        option3 = Console.ReadLine();
                                    }

                                    else
                                    {
                                        Console.WriteLine("The consumable you are trying to adjust does not exist yet. Please give a different input.");
                                    }
                                }
                            }

                            else if (option == "3")
                            {
                                foreach (Consumable i in ConsumableList)
                                {
                                    Console.WriteLine(i.getData());
                                }

                                Console.WriteLine("\n Type anything to go back.");
                                Console.Read();
                            }

                            else if (option == "4")
                            {
                                cons_to_string = new List<string>();

                                foreach (var Consumable in ConsumableList)
                                {
                                    cons_to_string.Add($"{ Consumable.name }.{ Consumable.amount }.{ Consumable.price }.{ Consumable.num }");
                                }

                                File.WriteAllLines(filepath, cons_to_string);
                            }

                            else if (option == "5")
                            {
                                programState = "loginMenu";
                            }

                            else if (option == "6")
                            {
                                program = "shutdown";
                                programState = "shutdown";
                            }

                            else
                            {
                                Console.WriteLine("Wrong answer! please try again.");
                            }
                        }
                    }
                }
            }


            //Shutdown data store sequence
            Console.WriteLine("Data storing started");
            List<string> adminOutput = new List<string>();
            foreach (admin admin in adminList)
            {
                adminOutput.Add(admin.name + "," + admin.email + "," + admin.phoneNumber + "," + admin.role + "," + admin.password + "," + admin.balance);
            }
            File.WriteAllLines(adminFile, adminOutput);
            List<string> customerOutput = new List<string>();
            foreach (customer customer in customerList)
            {
                customerOutput.Add(customer.name + "," + customer.email + "," + customer.phoneNumber + "," + customer.role + "," + customer.password + "," + customer.balance);
            }
            File.WriteAllLines(customerFile, customerOutput);
            List<string> managerOutput = new List<string>();
            foreach (manager manager in managerList)
            {
                managerOutput.Add(manager.name + "," + manager.email + "," + manager.phoneNumber + "," + manager.role + "," + manager.password + "," + manager.balance);
            }
            File.WriteAllLines(managerFile, managerOutput);
            List<string> catererOutput = new List<string>();
            foreach (caterer caterer in catererList)
            {
                catererOutput.Add(caterer.name + "," + caterer.email + "," + caterer.phoneNumber + "," + caterer.role + "," + caterer.password + "," + caterer.balance);
            }
            File.WriteAllLines(catererFile, catererOutput);
            Console.WriteLine("Data storing Finished");
            Environment.Exit(0);

        }
    }
}


