namespace TaxCalculator.Services.Interfaces;

public interface ITaxBandHandler
{
    public ITaxBandHandler? NextHandler { get; }

    public double Handle(double salary);
}