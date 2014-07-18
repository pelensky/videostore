namespace videostore
{
    using NUnit.Framework;

    [TestFixture]
    public class StatementTest
    {
        private Statement statement;

        [SetUp]
        public void Setup()
        {
            statement = new Statement("Customer Name");
        }

        [Test]
        public void TestSingleNewReleaseStatement()
        {
            statement.AddRental(new Rental(CreateNewRelease(), 3));

            statement.Generate();

            Assert.AreEqual(2, statement.FrequentRenterPoints);
            Assert.AreEqual(9.0, statement.AmountOwed);
        }

        [Test]
        public void TestDualNewReleaseStatement()
        {
            statement.AddRental(new Rental(CreateNewRelease(), 3));
            statement.AddRental(new Rental(CreateNewRelease(), 3));

            statement.Generate();

            Assert.AreEqual(4, statement.FrequentRenterPoints);
            Assert.AreEqual(18.0, statement.AmountOwed);
        }

        [Test]
        public void TestSingleChildrensStatement()
        {
            statement.AddRental(new Rental(CreateChildrensMovie(), 3));

            statement.Generate();

            Assert.AreEqual(1, statement.FrequentRenterPoints);
            Assert.AreEqual(1.5, statement.AmountOwed);
        }

        [Test]
        public void TestMultipleRegularStatement()
        {
            statement.AddRental(new Rental(CreateRegularMovie(), 1));
            statement.AddRental(new Rental(CreateRegularMovie(), 2));
            statement.AddRental(new Rental(CreateRegularMovie(), 3));

            statement.Generate();

            Assert.AreEqual(3, statement.FrequentRenterPoints);
            Assert.AreEqual(7.5, statement.AmountOwed);
        }

        [Test]
        public void TestFullStatementText()
        {
            statement.AddRental(new Rental(CreateRegularMovie(), 1));
            statement.AddRental(new Rental(CreateRegularMovie("Regular Movie 2"), 2));
            statement.AddRental(new Rental(CreateRegularMovie("Regular Movie 3"), 3));

            Assert.AreEqual("Rental Record for Customer Name\n" +
                            "\tRegular Movie\t2.0\n" +
                            "\tRegular Movie 2\t2.0\n" +
                            "\tRegular Movie 3\t3.5\n" +
                            "You owed 7.5\n" +
                            "You earned 3 frequent renter points\n", statement.Generate());
        }

        private static Movie CreateNewRelease()
        {
            return new Movie("New Release", Movie.NEW_RELEASE);
        }

        private static Movie CreateChildrensMovie()
        {
            return new Movie("Childrens Movie", Movie.CHILDRENS);
        }

        private static Movie CreateRegularMovie(string name = "Regular Movie")
        {
            return new Movie(name, Movie.REGULAR);
        }
    }
}