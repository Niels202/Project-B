using System;

namespace Fixed_project_B
{
    class Program
    {
        static void Main(string[] args)
        {
            user Niels = new user("Niels", 1234, "password", "0987411@hr.nl", "0610919232");
            cinema Gouda = new cinema("Burgemeester Jamessingel 25, 2803 WV Gouda", 3, "zondag 9:00 - 21:00\n maandag 9:00 - 21:00\n dinsdag 9:00 - 21:00\n woensdag 9:00 - 21:00\n donderdag 9:00 - 21:00\n vrijdag 9:00 - 21:00\n zaterdag 9:00 - 21:00\n" );
            Console.WriteLine(Gouda.getCinemaInfo());
        }
    }
}
