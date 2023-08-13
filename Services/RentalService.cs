using LearningInterfaces.Entities;

namespace LearningInterfaces.Services;
public class RentalService
{
    public double PricePerHour { get; private set; }
    public double PricePerDay { get; private set;}

    private ITaxService _taxService;

    //private BrazilTaxService _brazilTaxService = new BrazilTaxService();// -> bad choice

    public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
    {
        PricePerHour = pricePerHour;
        PricePerDay = pricePerDay;
        _taxService = taxService;//IoC
    }

    public void ProcessInvoice(CarRental carRental)
    {
        TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
        double basicPayment = 0.0;
        double tax = 0.0;

        if(duration.TotalHours <= 12)
            basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
        else
            basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
        
        tax = _taxService.Tax(basicPayment);

        carRental.Invoice = new Invoice(basicPayment, tax);

    }

}
