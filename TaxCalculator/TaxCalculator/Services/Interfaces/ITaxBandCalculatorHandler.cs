namespace TaxCalculator.Services.Interfaces;

public interface ITaxBandCalculatorHandler
{
    public ITaxBandCalculatorHandler? NextHandler { get; }

    public double Handle(double salary);
}