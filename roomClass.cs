using System;

public class  room
{
    public int numberOfSeats;
    public bool has3D;
    public string seatsMap;
    public string roomName;
    public room(int numberOfSeats, bool has3D, string seatsMap, string roomName)
    {
        this.numberOfSeats = numberOfSeats;
        this.has3D = has3D;
        this.seatsMap = seatsMap;
        this.roomName = roomName;
    }

    public string getRoomInfo()
    {
        if (this.has3D == true)
        {
            return this.roomName + " has " + this.numberOfSeats + " seats\n" + "This room has 3D\n" + this.seatsMap;
        }
        else
        {
            return this.roomName + " has " + this.numberOfSeats + " seats\n" + "This room does not have 3D\n" + this.seatsMap;
        }
    }
}