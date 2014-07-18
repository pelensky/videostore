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

        public Movie GetMovie()
        {
            return movie;
        }

        public string GetTitle()
        {
            return movie.GetTitle();
        }

        public double AmountFor()
        {
            double amount = 0;

            switch (GetMovie().GetPriceCode())
            {
                case Movie.REGULAR:
                    amount += 2;
                    if (daysRented > 2)
                        amount += (daysRented - 2)*1.5;
                    break;
                case Movie.NEW_RELEASE:
                    amount += daysRented*3;
                    break;
                case Movie.CHILDRENS:
                    amount += 1.5;
                    if (daysRented > 3)
                        amount += (daysRented - 3)*1.5;
                    break;
            }
            return amount;
        }

        public int FrequentRenterPoints()
        {
            var points = 1;

            if (GetMovie().GetPriceCode() == Movie.NEW_RELEASE && daysRented > 1)
                points++;
            return points;
        }
    }
}