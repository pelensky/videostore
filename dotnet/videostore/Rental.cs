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

        public static double AmountFor(Rental rental)
        {
            double amount = 0;

            switch (rental.GetMovie().GetPriceCode())
            {
                case Movie.REGULAR:
                    amount += 2;
                    if (rental.GetDaysRented() > 2)
                        amount += (rental.GetDaysRented() - 2)*1.5;
                    break;
                case Movie.NEW_RELEASE:
                    amount += rental.GetDaysRented()*3;
                    break;
                case Movie.CHILDRENS:
                    amount += 1.5;
                    if (rental.GetDaysRented() > 3)
                        amount += (rental.GetDaysRented() - 3)*1.5;
                    break;
            }
            return amount;
        }
    }
}