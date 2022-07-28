using TaxCalculator.Models.Interfaces;
using TaxCalculator.Models.TaxBands;

namespace TaxCalculator.Containers;

public static class TaxBandsContainer
{
    public static List<ITaxBand> GetTaxBandsAbc()
    {
        return new List<ITaxBand>
        {
            new TaxBandA(),
            new TaxBandB(),
            new TaxBandC()
        };
    }
}