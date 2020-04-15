using System;

public class cinema
{

    public string location;
    public int rooms;
    public string openingHours;

    public cinema(string location, int rooms, string openingHours)
    {
        this.location = location;
        this.rooms = rooms;
        this.openingHours = openingHours;
    }

    public string getCinemaInfo()
    {
        string cinemaInfo = this.location + "\n" + "There are " + this.rooms + " rooms" + "\n" + this.openingHours;
        return cinemaInfo;
    }

}
