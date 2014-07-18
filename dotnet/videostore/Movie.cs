namespace videostore
{
    public abstract class Movie
    {
        public const int CHILDRENS   = 2;
        public const int REGULAR	   = 0;
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

        public abstract double Price(int daysRented);

        public virtual int FrequentRenterPoints(int daysRented)
        {
            return 1;
       }
    }
}