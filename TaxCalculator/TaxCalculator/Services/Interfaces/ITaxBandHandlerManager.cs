using TaxCalculator.Models.Interfaces;

namespace TaxCalculator.Services.Interfaces;

public interface ITaxBandHandlerManager
{
    public ITaxBandHandler CreateChainOfResponsibility(List<ITaxBand> taxBands);
}