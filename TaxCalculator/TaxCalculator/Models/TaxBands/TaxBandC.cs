using TaxCalculator.Models.Interfaces;

namespace TaxCalculator.Models.TaxBands;

public class TaxBandC : ITaxBand
{
    public double MinimumLimit => 20000;
    public double MaximumLimit => double.MaxValue;
    public int TaxPercentage => 40;
}