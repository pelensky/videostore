namespace videostore
{
    class Rental
    {
        private readonly Movie movie;
        private readonly int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public string GetTitle()
        {
            return movie.GetTitle();
        }

        public double Price()
        {
            return movie.Price(daysRented);
        }

        public int FrequentRenterPoints()
        {
            return movie.FrequentRenterPoints(daysRented);

        }
    }
}