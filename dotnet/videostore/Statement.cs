using System;
using System.Collections;

namespace videostore
{
    class Statement
    {
        public int FrequentRenterPoints { get; set; }
        public double AmountOwed { get; set; }
        protected string Name { get; private set; }

        public Statement(String name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public String Generate()
        {
            AmountOwed = 0;
            FrequentRenterPoints = 0;

            var rentalsEnumerator = rentals.GetEnumerator();
            var result = "Rental Record for " + Name + "\n";

            while (rentalsEnumerator.MoveNext())
            {
                double thisAmount = 0;
                Rental each = (Rental) rentalsEnumerator.Current;

                // determines the amount for each line
                switch (each.GetMovie().GetPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.GetDaysRented() > 2)
                            thisAmount += (each.GetDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.GetDaysRented() * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.GetDaysRented() > 3)
                            thisAmount += (each.GetDaysRented() - 3) * 1.5;
                        break;
                }

                FrequentRenterPoints++;

                if (each.GetMovie().GetPriceCode() == Movie.NEW_RELEASE
                        && each.GetDaysRented() > 1)
                    FrequentRenterPoints++;

                result += "\t" + each.GetMovie().GetTitle() + "\t" + string.Format("{0:F1}", thisAmount) + "\n";
                AmountOwed += thisAmount;

            }

            result += "You owed " + string.Format("{0:F1}", AmountOwed) + "\n";
            result += "You earned " + FrequentRenterPoints + " frequent renter points\n";


            return result;
        }


        private ArrayList rentals = new ArrayList();
    }
}