using System;
using System.Collections;
using System.Collections.Generic;

namespace videostore
{
    class Statement
    {
        public int FrequentRenterPoints { get; set; }
        public double AmountOwed { get; set; }
        protected string Name { get; private set; }
        private readonly IList<Rental> rentals;

        public Statement(String name)
        {
            Name = name;
            rentals = new List<Rental>();
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public String Generate()
        {
            AmountOwed = 0;
            FrequentRenterPoints = 0;

            var result = "Rental Record for " + Name + "\n";
            
            foreach (var rental in rentals)
            {
                var thisAmount = Rental.AmountFor(rental);

                FrequentRenterPoints++;

                if (rental.GetMovie().GetPriceCode() == Movie.NEW_RELEASE
                        && rental.GetDaysRented() > 1)
                    FrequentRenterPoints++;

                result += "\t" + rental.GetMovie().GetTitle() + "\t" + string.Format("{0:F1}", thisAmount) + "\n";
                AmountOwed += thisAmount;
            }

            result += "You owed " + string.Format("{0:F1}", AmountOwed) + "\n";
            result += "You earned " + FrequentRenterPoints + " frequent renter points\n";
            return result;
        }
    }
}