using TaxCalculator.Models.Interfaces;

namespace TaxCalculator.Models.TaxBands;

public class TaxBandA : ITaxBand
{
    public double MinimumLimit => 0;
    public double MaximumLimit => 5000;
    public int TaxPercentage => 0;
}