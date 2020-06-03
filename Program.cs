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
            int x = 0;
            int cons_adjust = 0;            // A variable that gets the value that says which consumable from the list to adjust | line 131 |
            string userAge = "";
            string option = "";             // A variable that gets the value that says which option the user wants to select.
            string option2 = "";            // A variable that gets the value that says which option the user wants to select.
            string option3 = "";            // A variable that gets the value that says which option the user wants to select.
            string k2;                      // A variable that gets the value that says the user want to go back | line 201 |
            string loop = "";               // A variable to that stops the while-loop when needed | while-loop line 45  |
            string loop0 = "";              // A variable to that stops the while-loop when needed | while-loop line 69  |
            string loop1 = "";              // A variable to that stops the while-loop when needed | while-loop line 84  |
            string loop2 = "";              // A variable to that stops the while-loop when needed | while-loop line 125 |
            string loop3 = "";              // A variable to that stops the while-loop when needed | while-loop line 152 |
            string loop4 = "";              // A variable to that stops the while-loop when needed | while-loop line 166 |
            string typecheck0 = "";         // A varibale that gets a value assigned to it. That value gets checked if it is the right type to parse to the consumable object. | line 72  |
            string typecheck1 = "";         // A varibale that gets a value assigned to it. That value gets checked if it is the right type to parse to the consumable object. | line 87  |
            string typecheck2 = "";         // A varibale that gets a value assigned to it. That value gets checked if it is the right type to parse to the consumable object. | line 128 |
            string typecheck3 = "";         // A varibale that gets a value assigned to it. That value gets checked if it is the right type to parse to the consumable object. | line 154 |
            string typecheck4 = "";         // A varibale that gets a value assigned to it. That value gets checked if it is the right type to parse to the consumable object. | line 169 |
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
                
                customer newCustomer = new customer("","","","","", "",0, new List<string>());
                newCustomer.name = entries[0];
                newCustomer.email = entries[1];
                newCustomer.phoneNumber = entries[2];
                newCustomer.role = entries[3];
                newCustomer.password = entries[4];
                

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
                

                managerList.Add(newManager);
                users.Add(newManager.name, newManager.role);
            }

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create new user");
            Console.WriteLine("3. Exit");
            volgendeMenu = Console.ReadLine();
            while (program == "running")
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
                            if (users[enteredUsername] == "admin" )
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
                        new customer(userName, userEmail, userPhoneNumber, "customer", userPassword, userAge, 0, new List<string>());                       
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
                            //roomsDict.Add(nameOfRoom, intTicketPrice);
                            List<List<string>> newRoomMap = new List<List<string>>();
                            
                            for (int n = 0; n < numberOfRows; n++)
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
                            }
                            
                            Rooms.Add(new room(numberOfSeats, has3D, nameOfRoom, intTicketPrice, newRoomMap));
                            Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                            volgendeMenu = Console.ReadLine();
                            }
                            
                        
                            else if (volgendeMenu == "6")
                            {
                                Environment.Exit(0);
                            }
                            else if (volgendeMenu == "4")
                            {
                                List<string> seatCheckList = new List<string>()//Change this to check if input is int
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
                                        Console.Write("Row " + rowCounter + ". ");
                                        foreach(var e in roomsDict[nameOfRoom][mapTeller])
                                        {
                                            int intA = a+1;
                                            string stringA = intA.ToString();
                                            roomsDict[nameOfRoom][n].Add(stringA);
                                            newRoomMap[n].Add(stringA);
                                        }
                                    }
                                    
                                    Rooms.Add(new room(numberOfSeats, has3D, nameOfRoom, newRoomMap));
                                    Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
                                    volgendeMenu = Console.ReadLine();  
                                }
                                else if (volgendeMenu == "6")
                                {
                                    program = "Shutdown";
                                    programState = "Shutdown";
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
                                                    //if user has enough money
                                                    //currentUser.balance -= roomsDict[nameOfRoom].intTicketPrice;
                                                    rowCounter = 1;
                                                    mapTeller = 0;
                                                    foreach(var i in roomsDict[nameOfRoom])
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
                                                        Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                                                        volgendeMenu = Console.ReadLine(); 
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Unable to reserve this seat. This seat has already been reserved.");
                                                    Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                                                    volgendeMenu = Console.ReadLine();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nInvalid seat number.");
                                                Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                                                volgendeMenu = Console.ReadLine();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nInvalid row input.");
                                            Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                                            volgendeMenu = Console.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid room name, check if you have used the right format and make sure the room exists.");
                                        Console.WriteLine("\nWhere do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                                        volgendeMenu = Console.ReadLine();
                                    }
                                    Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application\n7. Create new user");
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
                        
                    }

                    else if (userMenu == "manager")
                    {
                        
                    }

                    else if (userMenu == "caterer")
                    {
                        List<Consumable> ConsumableList = new List<Consumable>();
                        while (loop != "stop") {

                            option2 = "";
                            option3 = "";

                            Console.WriteLine("Caterer Menu \n1. Add consumables \n2. Adjust consumables \n3. Show consumables\n4. Log out\n5. Exit application");
                            Console.WriteLine("choose option: "); option = Console.ReadLine();

                            if (option == "1")
                            {
                                Console.WriteLine("if you want to create / add a new consumable, type add. if you want to go back to the main menu, type back");
                                while (option2 != "back") {
                                    
                                    option2 = Console.ReadLine();

                                    if (option2 == "add")
                                    {

                                        option2 = "";
                                        ConsumableList.Add(new Consumable());
                                        Console.WriteLine("Creating new consumable... \n ");

                                        Console.WriteLine("Name of new consumable: ");
                                        ConsumableList[x].name = Console.ReadLine();

                                        while (loop0 != "stop")
                                        {
                                            Console.WriteLine("Amount in stock of new consumable: ");
                                            typecheck0 = Console.ReadLine();

                                            if (int.TryParse(typecheck0, out ConsumableList[x].amount)) {
                                                loop0 = "stop";
                                            }

                                            else {
                                                Console.WriteLine("Wrong input, please try again.");
                                            }
                                        }
                                        loop0 = "";

                                        while (loop1 != "stop")
                                        {
                                            Console.WriteLine("The price of the new consumable: ");
                                            typecheck1 = Console.ReadLine();

                                            if (int.TryParse(typecheck1, out ConsumableList[x].price))
                                            {
                                                loop1 = "stop";
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong input, please try again.");
                                            }
                                        }
                                        loop1 = "";
                                        ConsumableList[x].num += x;

                                        Console.WriteLine("Do you want to add / create another consumable (type add) or back out to the main menu and safe? (type back) ");

                                        option2 = "";
                                        x = x + 1;
                                    }

                                    else if (option2 == "back") {
                                        Console.WriteLine("");
                                    }

                                    else {
                                        Console.WriteLine("Wrong answer! Please try again.");
                                    }

                                }
                            }

                            else if (option == "2")
                            {
                                Console.WriteLine("if you want to adjust / change a consumable, press enter. If you want to go back to the main menu, type back");
                                option3 = Console.ReadLine();

                                while (option3 != "back") {

                                while (loop2 != "stop") {
                                    Console.WriteLine("Which consumable do you want to adjust? Type in the number of the consumable.");
                                    Console.WriteLine("You can find the number of the consumable with option 3 of the main menu called show consumables.");
                                    typecheck2 = Console.ReadLine();

                                    if (int.TryParse(typecheck2, out cons_adjust))
                                    {
                                        loop2 = "stop";
                                    }

                                    else
                                    {
                                        Console.WriteLine("Wrong input, please try again.");
                                    }   
                                }
                                loop2 = "";

                                if (cons_adjust <= x && cons_adjust >= 0)
                                    {
                                        Console.WriteLine("Unajusted consumable: ");
                                        Console.WriteLine(ConsumableList[cons_adjust].getData());

                                        Console.WriteLine("Change what you want to change. Fill in the old value for the things you want to stay the same. \n");

                                        Console.WriteLine("Name: ");
                                        ConsumableList[cons_adjust].name = Console.ReadLine();

                                        while (loop3 != "stop"){
                                            Console.WriteLine("Amount in stock: ");
                                            typecheck3 = Console.ReadLine();

                                            if (int.TryParse(typecheck3, out ConsumableList[cons_adjust].amount)) {
                                                loop3 = "stop";
                                            }

                                            else {
                                                Console.WriteLine("Wrong input, please try again.");
                                            }
                                        }
                                        loop3 = "";

                                        while (loop4 != "stop")
                                        {
                                            Console.WriteLine("The price: ");
                                            typecheck4 = Console.ReadLine();

                                            if (int.TryParse(typecheck4, out ConsumableList[cons_adjust].amount))
                                            {
                                                loop4 = "stop";
                                            }

                                            else
                                            {
                                                Console.WriteLine("Wrong input, please try again.");
                                            }
                                        }
                                        loop4 = "";

                                        Console.WriteLine("\n Do you want to adjust another consumable? \n If you want to adjust another consumable, press enter. If you want to go back to the main menu, type back");
                                        option3 = Console.ReadLine();
                                    }

                                    else {
                                        Console.WriteLine("The consumable you are trying to adjust does not exist yet. Please try again.");
                                    }
                                }
                            }

                            else if (option == "3")
                            {
                                foreach (Consumable i in ConsumableList) {
                                    Console.WriteLine(i.getData());

                                } 
                                Console.WriteLine("\n Type anything to go back.");
                                k2 = Console.ReadLine();
                            }

                            else
                            {
                                Console.WriteLine("Wrong answer! please try again.");
                            }
                        }//waarom deze??
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
            Console.WriteLine("Data storing Finished");
            List<string> catererOutput = new List<string>();
            foreach(caterer caterer in catererList)
            {
                catererOutput.Add(caterer.name+ ","+ caterer.email + ","+ caterer.phoneNumber + ","+ caterer.role + ","+ caterer.password+ ","+ caterer.balance);
            }
            File.WriteAllLines(catererFile, catererOutput);
            Console.WriteLine("Data storing Finished");
        }
        }
    }
            }
        }
    }
}




