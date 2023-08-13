using System;
using System.Globalization;
using LearningInterfaces.Entities;
using LearningInterfaces.Services;

Console.WriteLine("Enter rental data");
Console.Write("Car model: ");
string model = Console.ReadLine();
Console.Write("Pickup (dd/MM/yyyy hh:ss): ");
DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
Console.Write("Return (dd/MM/yyyy hh:ss): ");
DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

CarRental carRental= new CarRental(start, finish, new Vehicle(model));

Console.Write("Enter price per hour: ");
double hour = double.Parse(Console.ReadLine());
Console.Write("Enter price per day: ");
double day = double.Parse(Console.ReadLine());

RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());//DI
rentalService.ProcessInvoice(carRental);
Console.WriteLine("INVOICE:");
Console.WriteLine(carRental.Invoice);
