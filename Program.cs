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
            // list of variables: their name, cause and where to find them.
            int x = 0;
            int cons_adjust = 0;            // A variable that gets the value that says which consumable from the list to adjust | line 131 |
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
                                programState = "running";
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
                        new user(userName, userEmail, userPhoneNumber,  "customer");
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
            
            while (programState == "running")
            {

                if (currentUser.role == "admin")
                {
                    
                
                    Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Exit application\n5. Make reservation\n6. Log out");
                    volgendeMenu = Console.ReadLine();
                    Console.WriteLine("\n");
                    
                    while (programState == "running")
                    {

                        
                        if (volgendeMenu == "1")
                        {
                            Console.WriteLine(Gouda.getCinemaInfo());
                            Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
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
                            Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Exit Application\n5. Make reservation\n6. Log out");
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
                                    int intA = a+1;
                                    string stringA = intA.ToString();
                                    roomsDict[nameOfRoom][n].Add(stringA);
                                    newRoomMap[n].Add(stringA);
                                }
                            }
                            
                            Rooms.Add(new room(numberOfSeats, has3D, nameOfRoom, newRoomMap));
                            Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                            volgendeMenu = Console.ReadLine();  
                        }
                        else if (volgendeMenu == "6")
                        {
                            Environment.Exit(0);
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
                            Console.WriteLine("\nPlease enter the row and seat number you would like to reserve. If you have purchased multiple tickets the seat(s) to the right of the selected seat will automatically be chosen.\n\n");
                            //Console.WriteLine("Seat - 12345678910\n");
                            int dictCount = roomsDict[nameOfRoom].Count;
                            //for (int roomMapReservation = 0; roomMapReservation < dictCount; roomMapReservation++)
                            //{
                            //    Console.WriteLine(roomsDict[nameOfRoom][roomMapReservation]);
                            //}
                            int rowCounter = 1;
                            foreach(var i in roomsDict[nameOfRoom])
                            {
                                Console.Write("Row " + rowCounter + " - ");
                                rowCounter++;
                                foreach(var e in roomsDict[nameOfRoom][1])
                                {
                                    Console.Write(e);
                                    Console.Write(" ");
                                }
                                Console.Write("\n");
                            }
                            Console.Write("Row: ");
                            string strRow = Console.ReadLine();
                            Console.Write("Seat number: ");
                            string strSeat = Console.ReadLine();

                            if (rowCheckList.Contains(strRow))
                            {
                                if (seatCheckList.Contains(strSeat))
                                {
                                    int intRow = Convert.ToInt32(strRow);
                                    int intSeat = Convert.ToInt32(strSeat);
                                    if (roomsDict[nameOfRoom][intRow-1][intSeat-1] != "-")
                                    {
                                        roomsDict[nameOfRoom][intRow-1][intSeat-1] = "-";
                                        rowCounter = 1;
                                        foreach(var i in roomsDict[nameOfRoom])
                                        {
                                            Console.Write("Row " + rowCounter + " - ");
                                            rowCounter++;
                                            foreach(var e in roomsDict[nameOfRoom][1])
                                            {
                                                Console.Write(e);
                                                Console.Write(" ");
                                            }
                                            Console.Write("\n");
                                        }
                                        Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                                        volgendeMenu = Console.ReadLine(); 
                                    }
                                    else
                                    {
                                        Console.WriteLine("Unable to reserve this seat. This seat has already been reserved.");
                                        Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                                        volgendeMenu = Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid seat number.");
                                    Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                                    volgendeMenu = Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid row input.");
                                Console.WriteLine("Where do you want to go?\n1. Cinema Info\n2. Room Info\n3. Make New Room\n4. Make reservation\n5. Log out\n6. Exit Application");
                                volgendeMenu = Console.ReadLine();
                            }
                        }    
                        else if (volgendeMenu == "6")
                        {
                            programState = "loginMenu";
                        }
                            
                }       }
                
                else if (currentUser.role == "customer")
                {
                    
                }

                else if (currentUser.role == "manager")
                {
                    
                }

                else if (currentUser.role == "caterer")
                {
                    List<Consumable> ConsumableList = new List<Consumable>();
                    while (loop != "stop") {

                        option2 = "";
                        option3 = "";

                        Console.WriteLine("caterer menu \n1. Add consumables \n2. adjust consumables \n3. show consumables\n4. Exit application\n5. Log out");
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

                    }
                }    
            }
        }
        }
    }
}




