using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using TaxCalculator.Models.Interfaces;
using TaxCalculator.Models.TaxBands;
using TaxCalculator.Services;
using TaxCalculator.Services.Handlers;
using TaxCalculator.Services.Interfaces;
using Xunit;

namespace TaxCalculatorTests.Services;

public class TaxCalculatorServiceTests
{
    private TaxCalculatorService _taxCalculatorService;
    private readonly Mock<ITaxBandHandlerManager> _taxBandHandlerManagerMock;
    private readonly TaxBandHandler _taxBandAHandler;
    
    public TaxCalculatorServiceTests()
    {
        var taxBandBHandler = new TaxBandHandler(new TaxBandB());
        _taxBandAHandler = new TaxBandHandler(new TaxBandA(), taxBandBHandler);
        _taxBandHandlerManagerMock = new Mock<ITaxBandHandlerManager>();
    }

    [Fact]
    public void ShouldReturnCorrectTax()
    {
        // Arrange
        _taxBandHandlerManagerMock.Setup(tbchm => tbchm.CreateChainOfResponsibility(It.IsAny<List<ITaxBand>>()))
            .Returns(_taxBandAHandler);
        _taxCalculatorService = new TaxCalculatorService(_taxBandHandlerManagerMock.Object);
        
        // Act
        var taxFromSalary = _taxCalculatorService.GetTaxFromSalary(8000);

        // Arrange
        taxFromSalary.Should().Be(600);
    }

    [Fact]
    public void ShouldThrowArgumentNullExceptionWhenThereIsNoChainOfTaxBands()
    {
        // Arrange
        _taxBandHandlerManagerMock.Setup(tbchm => tbchm.CreateChainOfResponsibility(It.IsAny<List<ITaxBand>>()))
            .Throws<ArgumentNullException>();
        _taxCalculatorService = new TaxCalculatorService(_taxBandHandlerManagerMock.Object);
        
        // Act
        var func = () => _taxCalculatorService.GetTaxFromSalary(8000);

        // Arrange
        func.Should().Throw<ArgumentNullException>();
    }
}