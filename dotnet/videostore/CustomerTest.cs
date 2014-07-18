namespace videostore
{
    using NUnit.Framework;

    [TestFixture]
    public class CustomerTest
    {
        [SetUp]
        public void Setup()
        {
            statement = new Statement("Fred");
        }

        [Test]
        public void TestSingleNewReleaseStatement()
        {
            statement.AddRental(new Rental(new Movie("The Cell", Movie.NEW_RELEASE), 3));

            statement.Generate();

            Assert.AreEqual(2, statement.FrequentRenterPoints);
            Assert.AreEqual(9.0, statement.AmountOwed);
        }

        [Test]
        public void TestDualNewReleaseStatement()
        {
            statement.AddRental(new Rental(new Movie("The Cell", Movie.NEW_RELEASE), 3));
            statement.AddRental(new Rental(new Movie("The Tigger Movie", Movie.NEW_RELEASE), 3));

            statement.Generate();

            Assert.AreEqual(4, statement.FrequentRenterPoints);
            Assert.AreEqual(18.0, statement.AmountOwed);
        }

        [Test]
        public void TestSingleChildrensStatement()
        {
            statement.AddRental(new Rental(new Movie("The Tigger Movie", Movie.CHILDRENS), 3));

            statement.Generate();

            Assert.AreEqual(1, statement.FrequentRenterPoints);
            Assert.AreEqual(1.5, statement.AmountOwed);
        }

        [Test]
        public void TestMultipleRegularStatement()
        {
            statement.AddRental(new Rental(new Movie("Plan 9 from Outer Space", Movie.REGULAR), 1));
            statement.AddRental(new Rental(new Movie("8 1/2", Movie.REGULAR), 2));
            statement.AddRental(new Rental(new Movie("Eraserhead", Movie.REGULAR), 3));

            statement.Generate();

            Assert.AreEqual(3, statement.FrequentRenterPoints);
            Assert.AreEqual(7.5, statement.AmountOwed);
        }

        [Test]
        public void TestFullStatementText()
        {
            statement.AddRental(new Rental(new Movie("Plan 9 from Outer Space", Movie.REGULAR), 1));
            statement.AddRental(new Rental(new Movie("8 1/2", Movie.REGULAR), 2));
            statement.AddRental(new Rental(new Movie("Eraserhead", Movie.REGULAR), 3));

            Assert.AreEqual("Rental Record for Fred\n\tPlan 9 from Outer Space\t2.0\n\t8 1/2\t2.0\n\tEraserhead\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points\n", statement.Generate());
        }

        private Statement statement;
    }
}