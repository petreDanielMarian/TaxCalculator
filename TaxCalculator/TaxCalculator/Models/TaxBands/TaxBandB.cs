using TaxCalculator.Models.Interfaces;

namespace TaxCalculator.Models.TaxBands;

public class TaxBandB : ITaxBand
{
    public double MinimumLimit => 5000;
    public double MaximumLimit => 20000;
    public int TaxPercentage => 20;
}