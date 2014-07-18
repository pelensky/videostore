using System;
using System.Collections.Generic;
using System.Linq;

namespace videostore
{
    class Statement
    {
        public Statement(String name)
        {
            Name = name;
            rentals = new List<Rental>();
        }

        protected string Name { get; private set; }
        private readonly IList<Rental> rentals;

        public double AmountOwed
        {
            get { return rentals.Sum(rental => rental.Price()); }
        }

        public int FrequentRenterPoints
        {
            get { return rentals.Sum(rental => rental.FrequentRenterPoints()); }
        }       
        
        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public String Generate()
        {
            var result = "Rental Record for " + Name + "\n";
            
            foreach (var rental in rentals)
            {
                result += "\t"
                       + rental.GetTitle() + "\t"
                       + string.Format("{0:F1}", rental.Price()) + "\n";
            }

            result += "You owed " + string.Format("{0:F1}", AmountOwed) + "\n";
            result += "You earned " + FrequentRenterPoints + " frequent renter points\n";
            return result;
        }
    }
}