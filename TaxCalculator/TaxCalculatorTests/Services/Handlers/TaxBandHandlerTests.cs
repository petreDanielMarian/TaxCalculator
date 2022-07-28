using FluentAssertions;
using TaxCalculator.Models.TaxBands;
using TaxCalculator.Services.Handlers;
using Xunit;

namespace TaxCalculatorTests.Services.Handlers;

public class TaxBandHandlerTests
{
    private readonly TaxBandHandler _taxBandAHandler;
    
    public TaxBandHandlerTests()
    {
        var taxBandCHandler = new TaxBandHandler(new TaxBandC());
        var taxBandBHandler = new TaxBandHandler(new TaxBandB(), taxBandCHandler);
        _taxBandAHandler = new TaxBandHandler(new TaxBandA(), taxBandBHandler);
    }
    
    [Fact]
    public void ShouldReturnCorrectTaxFromOneTaxBand()
    {
        // Arrange + Act
        var tax = _taxBandAHandler.Handle(4000);

        // Assert
        tax.Should().Be(0);
    }
    
    [Fact]
    public void ShouldReturnCorrectTaxFromTwoTaxBands()
    {
        // Arrange + Act
        var tax = _taxBandAHandler.Handle(9000);

        // Assert
        tax.Should().Be(800);
    }
    
    [Fact]
    public void ShouldReturnCorrectTaxFromThreeTaxBands()
    {
        // Arrange + Act
        var tax = _taxBandAHandler.Handle(25000);

        // Assert
        tax.Should().Be(5000);
    }
}