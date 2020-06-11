class Movie
{
    public string movieName;
    public string movieDescription;
    public string movieGenre;
    public int minimalAge;
    public string movieDate;

    public Movie(string movieName, string movieDescription, string movieGenre, int minimalAge, string movieDate)
    {
        this.movieName = movieName;
        this.movieDescription = movieDescription;
        this.movieGenre = movieGenre;
        this.minimalAge = minimalAge;
        this.movieDate = movieDate;
    }
}