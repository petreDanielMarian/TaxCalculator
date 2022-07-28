using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services;

public class TaxCalculatorService : ITaxCalculatorService
{
    public double GetTaxFromSalary(double salary)
    {
        var taxAHandler = TaxBandCalculatorHandlerManager.CreateChainOfResponsibility();
        
        return taxAHandler.Handle(salary);
    }
}