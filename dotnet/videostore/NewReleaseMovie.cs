
namespace videostore
{
    class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title, int priceCode) : base(title, priceCode)
        {
        }

        public override double Price(int daysRented)
        {
            return daysRented*3;
        }

        public override int FrequentRenterPoints(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }
}
