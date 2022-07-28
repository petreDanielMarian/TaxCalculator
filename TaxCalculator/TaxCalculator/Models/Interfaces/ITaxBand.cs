namespace TaxCalculator.Models.Interfaces;

public interface ITaxBand
{
    public double MinimumLimit { get; }
    public double MaximumLimit { get; }
    public double MaximumTaxableAmount => MaximumLimit - MinimumLimit;
    public int TaxPercentage { get; }
}