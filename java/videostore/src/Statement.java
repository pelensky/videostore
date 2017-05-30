import java.util.ArrayList;
import java.util.List;

class Statement {

  private final String customerName;
  private final List<Rental> rentals = new ArrayList<Rental>();
  private double totalAmount;
  private int frequentRenterPoints;

  Statement(String customerName) {
    this.customerName = customerName;
  }

  void addRental(Rental rental) {
    rentals.add(rental);
  }

  String generate() {
    clearTotals();
    String statementText = header();
    statementText += rentalLines();
    statementText += footer();
    return statementText;
  }

  private void clearTotals() {
    totalAmount = 0;
    frequentRenterPoints = 0;
  }

  private String header() {
    return String.format("Rental Record for %s\n", customerName);
  }

  private String rentalLines() {
    String rentalLines = "";
    for (Rental rental : rentals) {
      rentalLines += rentalLine(rental);
    }
    return rentalLines;
  }

  private String rentalLine(Rental rental) {
    double rentalAmount = rental.determineAmount();
    frequentRenterPoints += rental.determineFrequentRenterPoints();
    totalAmount += rentalAmount;
    return formatRentalLine(rental, rentalAmount);
  }

  private String formatRentalLine(Rental rental, double rentalAmount) {
    return String.format("\t%s\t%.1f\n", rental.getTitle(), rentalAmount);
  }

  private String footer() {
    return String.format(
        "You owed %.1f\n" + "You earned %d frequent renter points\n",
        totalAmount, frequentRenterPoints);
  }

  double getTotal() {
    return totalAmount;
  }

  int getFrequentRenterPoints() {
    return frequentRenterPoints;
  }
}
