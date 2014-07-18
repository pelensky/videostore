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
            this.priceCode 	= priceCode;
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

        public double Price(int daysRented)
        {
            var amount = 0.0;
            switch (GetPriceCode())
            {
                case Movie.REGULAR:
                    amount += 2;
                    if (daysRented > 2)
                        amount += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    amount += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    amount += 1.5;
                    if (daysRented > 3)
                        amount += (daysRented - 3)*1.5;
                    break;
            }
            return amount;
        }
    }
}