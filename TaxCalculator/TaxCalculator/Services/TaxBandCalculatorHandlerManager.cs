using TaxCalculator.Models.TaxBands;
using TaxCalculator.Services.Handlers;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services;

public static class TaxBandCalculatorHandlerManager
{
    public static ITaxBandCalculatorHandler CreateChainOfResponsibility()
    {
        var taxCHandler = new TaxBandCalculatorHandler(new TaxBandC());
        var taxBHandler = new TaxBandCalculatorHandler(new TaxBandB(), taxCHandler);
        var taxAHandler = new TaxBandCalculatorHandler(new TaxBandA(), taxBHandler);

        return taxAHandler;
    }
}