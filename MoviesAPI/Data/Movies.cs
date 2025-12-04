namespace MoviesAPI.Data
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public string Genre { get; set; } = null!;
    }
}