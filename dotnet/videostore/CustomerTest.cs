namespace videostore
{
    using NUnit.Framework;

    [TestFixture]
    public class CustomerTest
    {
        [SetUp]
        public void Setup()
        {
            customer = new Customer("Fred");
        }

        [Test]
        public void TestSingleNewReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("The Cell", Movie.NEW_RELEASE), 3));

            customer.Generate();

            Assert.AreEqual(2, customer.FrequentRenterPoints);
            Assert.AreEqual(9.0, customer.AmountOwed);
        }

        [Test]
        public void TestDualNewReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("The Cell", Movie.NEW_RELEASE), 3));
            customer.AddRental(new Rental(new Movie("The Tigger Movie", Movie.NEW_RELEASE), 3));

            customer.Generate();

            Assert.AreEqual(4, customer.FrequentRenterPoints);
            Assert.AreEqual(18.0, customer.AmountOwed);
        }

        [Test]
        public void TestSingleChildrensStatement()
        {
            customer.AddRental(new Rental(new Movie("The Tigger Movie", Movie.CHILDRENS), 3));

            customer.Generate();

            Assert.AreEqual(1, customer.FrequentRenterPoints);
            Assert.AreEqual(1.5, customer.AmountOwed);
        }

        [Test]
        public void TestMultipleRegularStatement()
        {
            customer.AddRental(new Rental(new Movie("Plan 9 from Outer Space", Movie.REGULAR), 1));
            customer.AddRental(new Rental(new Movie("8 1/2", Movie.REGULAR), 2));
            customer.AddRental(new Rental(new Movie("Eraserhead", Movie.REGULAR), 3));

            customer.Generate();

            Assert.AreEqual(3, customer.FrequentRenterPoints);
            Assert.AreEqual(7.5, customer.AmountOwed);
        }

        [Test]
        public void TestFullStatementText()
        {
            customer.AddRental(new Rental(new Movie("Plan 9 from Outer Space", Movie.REGULAR), 1));
            customer.AddRental(new Rental(new Movie("8 1/2", Movie.REGULAR), 2));
            customer.AddRental(new Rental(new Movie("Eraserhead", Movie.REGULAR), 3));

            Assert.AreEqual("Rental Record for Fred\n\tPlan 9 from Outer Space\t2.0\n\t8 1/2\t2.0\n\tEraserhead\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points\n", customer.Generate());
        }

        private Customer customer;
    }
}