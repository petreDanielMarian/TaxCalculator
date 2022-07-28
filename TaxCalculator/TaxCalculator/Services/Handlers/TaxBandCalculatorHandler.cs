using TaxCalculator.Models.Interfaces;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services.Handlers;

public class TaxBandCalculatorHandler : ITaxBandCalculatorHandler
{
    private ITaxBand TaxBand { get; }
    public ITaxBandCalculatorHandler? NextHandler { get; }

    public TaxBandCalculatorHandler(ITaxBand taxBand, ITaxBandCalculatorHandler? nextHandler = null)
    {
        TaxBand = taxBand;
        NextHandler = nextHandler;
    }

    public double Handle(double salary)
    {
        var taxableSalary = salary - TaxBand.MaximumTaxableAmount;
        
        if (taxableSalary <= 0)
        {
            return salary * TaxBand.TaxPercentage / 100;
        }
        
        var taxApplied = Math.Min(salary, TaxBand.MaximumTaxableAmount) * TaxBand.TaxPercentage / 100;
        
        return taxApplied + NextHandler?.Handle(taxableSalary) ?? 0;
    }
}