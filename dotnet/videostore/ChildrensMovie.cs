namespace videostore
{
    class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title) : base(title)
        {
        }

        public override double Price(int daysRented)
        {
            var price = 1.5;
            if (daysRented > 3)
                price += (daysRented - 3) * 1.5;

            return price;
        }
    }
}
