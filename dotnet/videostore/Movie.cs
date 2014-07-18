namespace videostore
{
    public abstract class Movie
    {
        public string Title { get; protected set; }

        public Movie (string title) {
            Title = title;
        }
        public abstract double Price(int daysRented);

        public virtual int FrequentRenterPoints(int daysRented)
        {
            return 1;
       }
    }
}