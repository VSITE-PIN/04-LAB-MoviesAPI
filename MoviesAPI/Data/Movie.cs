namespace MoviesAPI.Data
{
    public class Movie
    {
        internal object MovieAdded;
        internal object MovieDeleted;

        public int Id { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public string? Genre { get; set; }
        public object Title { get; internal set; }
    }
}
