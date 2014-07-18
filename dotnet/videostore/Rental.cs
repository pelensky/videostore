namespace videostore
{
    class Rental
    {
        private Movie movie;
        private int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return daysRented;
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
                    if (GetDaysRented() > 2)
                        amount += (GetDaysRented() - 2)*1.5;
                    break;
                case Movie.NEW_RELEASE:
                    amount += GetDaysRented()*3;
                    break;
                case Movie.CHILDRENS:
                    amount += 1.5;
                    if (GetDaysRented() > 3)
                        amount += (GetDaysRented() - 3)*1.5;
                    break;
            }
            return amount;
        }

        public int FrequentRenterPoints()
        {
            var points = 1;

            if (GetMovie().GetPriceCode() == Movie.NEW_RELEASE && GetDaysRented() > 1)
                points++;
            return points;
        }
    }
}