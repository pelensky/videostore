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
            var points = 1;

            if (movie.GetPriceCode() == Movie.NEW_RELEASE && daysRented > 1)
                points++;
            return points;
        }
    }
}