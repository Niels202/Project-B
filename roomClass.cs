using System;
using System.Collections.Generic;

public class  room
{
    public int numberOfSeats;
    public bool has3D;
    public List<List<string>> seatsMap;
    public string roomName;
    //public int intRow;
    //public int intSeat;
    public room(int numberOfSeats, bool has3D, string roomName, List<List<string>> seatsMap)
    {
        this.numberOfSeats = numberOfSeats;
        this.has3D = has3D;
        this.roomName = roomName;
        this.seatsMap = seatsMap;
        //this.intRow = intRow; Misschien later nodig om de stap "Hoeveel stoelen zijn er in de kamer" te automatiseren door intRow*intSeat te doen.
        //this.intSeat = intSeat;
    }

    public string getRoomInfo()
    {
        if (this.has3D == true)
        {
            
            return roomName + " has " + numberOfSeats + " seats\n" + "This room has 3D";
        }
        else
        {
            return roomName + " has " + numberOfSeats + " seats\n" + "This room does not have 3D\n";
        }
    }
}