namespace videostore
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title) : base(title)
        {
        }

        public override double Price(int daysRented)
        {
            var price = 2.0;
            if (daysRented > 2)
                price += (daysRented - 2) * 1.5;

            return price;
        }
    }
}
