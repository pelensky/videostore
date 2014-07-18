
namespace videostore
{
    class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title) : base(title)
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
