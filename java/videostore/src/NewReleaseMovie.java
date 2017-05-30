class NewReleaseMovie extends Movie {
  NewReleaseMovie(String title) {
    super(title);
  }

  @Override
  double determineAmount(int daysRented) {
    return daysRented * 3;
  }

  @Override
  int determineFrequentRenterPoints(int daysRented) {
    return (daysRented > 1) ? 2 : 1;
  }
}
