using System;
using System.Collections.Generic;
public class reservationTicket
{
    public string movie;
    public string strRow;
    public int intRow;
    public string strSeat;
    public int intSeat;
    public int reservationNumber;
    public int seatRow;
    public int seatNumber;
    public int price;
    string[] seats = {"□", "□", "□", "□", "□", "□", "□", "□", "□", "□"};
    List<string> seatCheckList = new List<string>()
    {
        "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
    };

    List<string> rowCheckList = new List<string>()
    {
        "1", "2", "3", "4", "5", "6"
    };



    public reservationTicket(string movie, int reservationNumber, int seatRow, int seatNumber, int price)
    {   
        this.movie = movie;
        this.reservationNumber = reservationNumber;
        this.seatRow = seatRow;
        this.seatNumber = seatNumber;
        this.price = price;
    }

    public void chooseSeat(string strRow, int intRow, string strSeat, int intSeat)
    {
        List<string> Row1 = new List<string>(seats);

        List<string> Row2 = new List<string>(seats);
        
        List<string> Row3 = new List<string>(seats);
        
        List<string> Row4 = new List<string>(seats);
        
        List<string> Row5 = new List<string>(seats);
        
        List<string> Row6 = new List<string>(seats);
        
        List<List<string>> rowList = new List<List<string>>()
        {
            Row1, Row2, Row3, Row4, Row5, Row6
        };
        
        this.strRow = strRow;
        this.intRow = intRow;
        this.strSeat = strSeat;
        this.intSeat = intSeat;
        
        Console.WriteLine("Please enter the row and seat number you would like to reserve. If you have purchased multiple tickets the seat(s) to the right of the selected seat will automatically be chosen.\n\n");
        Console.WriteLine("Seat - 12345678910\n", "Row 1 -", Row1, "\n", "Row 2 -", Row2, "\n", "Row 3 -", Row3, "\n", "Row 4 -", Row4, "\n", "Row 5 -", Row5, "\n", "Row 6 -", Row6);
        Console.Write("Row: ");
        strRow = Console.ReadLine();
        Console.Write("Seat number: ");
        strSeat = Console.ReadLine();

        if (rowCheckList.Contains(strRow))
        {
            if (seatCheckList.Contains(strSeat))
            {
                intRow = Convert.ToInt32(strRow);
                intSeat = Convert.ToInt32(strSeat);
                rowList[intRow-1][intSeat-1] = "■";
                Console.WriteLine("Seat - 12345678910\n", "Row 1 -", Row1, "\n", "Row 2 -", Row2, "\n", "Row 3 -", Row3, "\n", "Row 4 -", Row4, "\n", "Row 5 -", Row5, "\n", "Row 6 -", Row6);
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


}