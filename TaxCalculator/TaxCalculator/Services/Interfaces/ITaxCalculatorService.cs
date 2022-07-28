namespace TaxCalculator.Services.Interfaces;

public interface ITaxCalculatorService
{
    double GetTaxFromSalary(double salary);
}