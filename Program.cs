using System.Collections.Generic;
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
            
            // list of variables: their name, cause and where to find them.
            string program = "running";
            string userAge = "";
            bool has3D = true;
            string programState = "loginMenu";
            string login = "notYetDone";
            string volgendeMenu = "";
            string userMenu = "";
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            user currentUser = new user("","","","","",  0, new List<string>());
            admin currentAdmin = new admin("","","","","",0,new List<string>());
            customer currentCustomer = new customer("","","","","","",0,new List<string>());
            caterer currentCaterer = new caterer("","","","","",0,new List<string>());
            manager currentManager = new manager("","","","","",0,new List<string>());
            cinema Gouda = new cinema("Burgemeester Jamessingel 25, 2803 WV Gouda", 3, "zondag 9:00 - 21:00\nmaandag 9:00 - 21:00\ndinsdag 9:00 - 21:00\nwoensdag 9:00 - 21:00\ndonderdag 9:00 - 21:00\nvrijdag 9:00 - 21:00\nzaterdag 9:00 - 21:00\n");
            Dictionary<string, List<List<string>>> roomsDict = new Dictionary<string, List<List<string>>>();
            string nameOfRoom = "notGiven";
            List<object> Rooms = new List<object>();
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
            string adminFile = Path.GetFullPath("adminFile.txt");
            string customerFile = Path.GetFullPath("customerFile.txt");
            string managerFile = Path.GetFullPath("managerFile.txt");
            string catererFile = Path.GetFullPath("catererFile.txt");

            List<string> adminFileLines = File.ReadAllLines(adminFile).ToList();
            foreach (var line in adminFileLines)
            {
                string[] entries = line.Split(',');
                
                admin newAdmin = new admin("","","","","",  100000, new List<string>());
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
                
                customer newCustomer = new customer("","","","","", "", 0, new List<string>());
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
                
                caterer newCaterer = new caterer("","","","","", 0, new List<string>());
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
                
                manager newManager = new manager("","","","","", 0, new List<string>());
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
                            else if (users[enteredUsername] == "admin" )
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
                            else if (users[enteredUsername] == "customer" )
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
                            else if (users[enteredUsername] == "caterer" )
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
                            else if (users[enteredUsername] == "manager" )
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
                        Environment.Exit(0);
                    }
            
                            
            
                while (programState == "running")
                {

                    if (userMenu == "admin")
                    {
                        
                        Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit application\n7. Create new user");
                        volgendeMenu = Console.ReadLine();
                        Console.WriteLine("\n");
                        
                        
                        while (programState == "running")
                        {

                            
                            if (volgendeMenu == "1")
                            {
                                Console.WriteLine(Gouda.getCinemaInfo());
                                Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
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
                                                Console.Write(" ");
                                            }
                                            Console.Write("\n");
                                        } 
                                    }
                                }
                                Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
                                volgendeMenu = Console.ReadLine();
                            }    
                            else if (volgendeMenu == "6")
                            {
                                program = "shutdown";
                                programState = "shutdown";
                            }
                            else if (volgendeMenu == "4")
                            {
                                List<string> seatCheckList = new List<string>()
                                {
                                    "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
                                };

                                List<string> rowCheckList = new List<string>()
                                {
                                    "1", "2", "3", "4", "5", "6"
                                };
                                Console.WriteLine("\nInput the name of the room you would like to reserve tickets in the following format \"Room 1\"\n");
                                nameOfRoom = Console.ReadLine(); 
                                Console.WriteLine("\n");
                                //roomsDict[roomName][rij][stoel]
                                int rowCounter = 1;
                                int mapTeller = 0;
                                if (roomsDict.ContainsKey(nameOfRoom))
                                {
                                    int dictCount = roomsDict[nameOfRoom].Count;
                                    foreach(var i in roomsDict[nameOfRoom])
                                    {
                                        Console.Write("Row " + rowCounter + " - ");
                                        foreach(var e in roomsDict[nameOfRoom][mapTeller])
                                        {
                                            Console.Write(e);
                                            Console.Write(" ");
                                        }
                                        rowCounter++;
                                        mapTeller++;
                                        Console.Write("\n");
                                    }
                                    Console.WriteLine("\nPlease enter the row and seat number you would like to reserve.");
                                    Console.Write("Row: ");
                                    string strRow = Console.ReadLine();
                                    Console.Write("Seat number: ");
                                    string strSeat = Console.ReadLine();
                                    Console.WriteLine("\n");

                                    if (rowCheckList.Contains(strRow))
                                    {
                                        if (seatCheckList.Contains(strSeat))
                                        {
                                            int intRow = Convert.ToInt32(strRow);
                                            int intSeat = Convert.ToInt32(strSeat);
                                            if (roomsDict[nameOfRoom][intRow-1][intSeat-1] != "-")
                                            {
                                                //roomsDict[roomName][rij][stoel]
                                                roomsDict[nameOfRoom][intRow-1][intSeat-1] = "-";
                                                rowCounter = 1;
                                                mapTeller = 0;
                                                foreach(var i in roomsDict[nameOfRoom])
                                                {
                                                    Console.Write("Row " + rowCounter + ". ");
                                                    foreach(var e in roomsDict[nameOfRoom][mapTeller])
                                                    {
                                                        Console.Write(e);
                                                        Console.Write(" ");
                                                    }
                                                    rowCounter++;
                                                    mapTeller++;
                                                    Console.Write("\n");
                                                }
                                                Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
                                                volgendeMenu = Console.ReadLine(); 
                                            }
                                            else
                                            {
                                                Console.WriteLine("Unable to reserve this seat. This seat has already been reserved.");
                                                Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
                                                volgendeMenu = Console.ReadLine();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nInvalid seat number.");
                                            Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
                                            volgendeMenu = Console.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid row input.");
                                        Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
                                        volgendeMenu = Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid room name, check if you have used the right format and make sure the room exists.");
                                    Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
                                    volgendeMenu = Console.ReadLine();
                                }
                            }
                            else if (volgendeMenu == "3")
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
                                int numberOfSeats = numberOfRows*numberOfSeatsPerRow;
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
                                        int intA = a+1;
                                        string stringA = intA.ToString();
                                        roomsDict[nameOfRoom][n].Add(stringA);
                                        newRoomMap[n].Add(stringA);
                                    }
                                }
                                    
                                Rooms.Add(new room(numberOfSeats, has3D, nameOfRoom, intTicketPrice, newRoomMap));
                                Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
                                volgendeMenu = Console.ReadLine();  
                            }    

                                
                            else if (volgendeMenu == "5")
                            {
                                programState = "loginMenu";
                            }
                            else if (volgendeMenu == "7")
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
                                    managerList.Add(new manager(userName, userEmail, userPhoneNumber, userRole, userPassword,0, new List<string>()));
                                }
                                
                                users.Add(userName, userRole);
                                Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
                                volgendeMenu = Console.ReadLine();
                            }
                            
                                
                    
                    else if (userMenu == "customer")
                    {

                        
                        while (programState == "running")
                            
                            if (volgendeMenu == "1")
                            {
                            program = "shutdown";
                            programState = "shutdown";
                            }
                            if (volgendeMenu == "2")
                            {
                                
                            }
                    }

                    else if (userMenu == "manager")
                    {
                        while (programState == "running")
                            {
                            program = "shutdown";
                            programState = "shutdown";
                            }
                    }

                    else if (userMenu == "caterer")
                    {
                        
                        while (programState == "running")
                            {
                            program = "shutdown";
                            programState = "shutdown";
                            }
                    }
                }    
            }


            //Shutdown data store sequence
            Console.WriteLine("Data storing started");
            List<string> adminOutput = new List<string>();
            foreach(admin admin in adminList)
            {
                adminOutput.Add(admin.name+ ","+ admin.email + ","+ admin.phoneNumber + ","+ admin.role + ","+ admin.password+ ","+ admin.balance);
            }
            File.WriteAllLines(adminFile, adminOutput);
            List<string> customerOutput = new List<string>();
            foreach(customer customer in customerList)
            {
                customerOutput.Add(customer.name+ ","+ customer.email + ","+ customer.phoneNumber + ","+ customer.role + ","+ customer.password+ ","+ customer.balance);
            }
            File.WriteAllLines(customerFile, customerOutput);
            List<string> managerOutput = new List<string>();
            foreach(manager manager in managerList)
            {
                managerOutput.Add(manager.name+ ","+ manager.email + ","+ manager.phoneNumber + ","+ manager.role + ","+ manager.password+ ","+ manager.balance);
            }
            File.WriteAllLines(managerFile, managerOutput);
            List<string> catererOutput = new List<string>();
            foreach(caterer caterer in catererList)
            {
                catererOutput.Add(caterer.name+ ","+ caterer.email + ","+ caterer.phoneNumber + ","+ caterer.role + ","+ caterer.password+ ","+ caterer.balance);
            }
            File.WriteAllLines(catererFile, catererOutput);
            Console.WriteLine("Data storing Finished");
            Environment.Exit(0);
            }
        }
    }
}
    }}


