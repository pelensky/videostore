namespace videostore
{
    public class Movie
    {
        public const int CHILDRENS   = 2;
        public const int REGULAR 	   = 0;
        public const int NEW_RELEASE = 1;

        private string title;
        private int priceCode;

        public Movie (string title, int priceCode) {
            this.title 		= title;
            SetPriceCode(priceCode);
        }

        public int GetPriceCode () {
            return priceCode;
        }

        public void SetPriceCode (int code) {
            priceCode = code;
        }

        public string GetTitle () {
            return title;
        }

        public virtual double Price(int daysRented)
        {
            var price = 0.0;
            switch (GetPriceCode())
            {
               case NEW_RELEASE:
                    price += daysRented * 3;
                    break;
                case CHILDRENS:
                    price += 1.5;
                    if (daysRented > 3)
                        price += (daysRented - 3)*1.5;
                    break;
            }
            return price;
        }

        public int FrequentRenterPoints(int daysRented)
        {
            var points = 1;

            if (GetPriceCode() == NEW_RELEASE && daysRented > 1)
                points++;
            return points;
        }
    }
}