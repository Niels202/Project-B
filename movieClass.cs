class Movie
{
    public string movieName;
    public string movieDescription;
    public string movieGenre;
    public string minimalAge;
    public int intTicketPrice;

    public Movie(string movieName, string movieDescription, string movieGenre, string minimalAge, int intTicketPrice)
    {
        this.movieName = movieName;
        this.movieDescription = movieDescription;
        this.movieGenre = movieGenre;
        this.minimalAge = minimalAge;
        this.intTicketPrice = intTicketPrice;
    }
}