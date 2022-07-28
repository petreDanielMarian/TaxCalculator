using TaxCalculator.Containers;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services;

public class TaxCalculatorService : ITaxCalculatorService
{
    private readonly ITaxBandHandlerManager _taxBandHandlerManager;

    public TaxCalculatorService(ITaxBandHandlerManager taxBandHandlerManager)
    {
        _taxBandHandlerManager = taxBandHandlerManager;
    }
    
    public double GetTaxFromSalary(double salary)
    {
        try
        {
            var firstTaxHandler = _taxBandHandlerManager.CreateChainOfResponsibility(TaxBandsContainer.GetTaxBandsAbc());

            return firstTaxHandler.Handle(salary);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("No TaxBands found to be applied!");
            throw;
        }
    }
}