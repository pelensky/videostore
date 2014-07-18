namespace videostore
{
    public abstract class Movie
    {
        private string title;

        public Movie (string title) {
            this.title 		= title;
        }
        public string GetTitle () {
            return title;
        }
        public abstract double Price(int daysRented);

        public virtual int FrequentRenterPoints(int daysRented)
        {
            return 1;
       }
    }
}