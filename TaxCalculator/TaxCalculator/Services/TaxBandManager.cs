using TaxCalculator.ExtensionMethods;
using TaxCalculator.Models.Interfaces;
using TaxCalculator.Services.Handlers;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services;

public class TaxBandHandlerManager : ITaxBandHandlerManager
{
    public ITaxBandHandler CreateChainOfResponsibility(List<ITaxBand> taxBands)
    {
        if (taxBands.IsNullOrEmpty())
        {
            throw new ArgumentNullException();
        }

        TaxBandHandler nextHandler = null!;
        for (var index = taxBands.Count - 1; index >= 0; index--)
        {
            if (index == taxBands.Count - 1)
            {
                nextHandler =  new TaxBandHandler(taxBands[index]);
                continue;
            }

            nextHandler = new TaxBandHandler(taxBands[index], nextHandler);
        }

        return nextHandler;
    }
}