using System;
using System.Collections.Generic;
using FluentAssertions;
using TaxCalculator.Models.Interfaces;
using TaxCalculator.Models.TaxBands;
using TaxCalculator.Services;
using Xunit;

namespace TaxCalculatorTests.Services;

public class TaxBandHandlerManagerTests
{
    private readonly List<ITaxBand> _taxBands;
    private readonly TaxBandHandlerManager _taxBandHandlerManager;
    
    public TaxBandHandlerManagerTests()
    {
        _taxBandHandlerManager = new TaxBandHandlerManager();
        _taxBands = new List<ITaxBand>();
    }
    
    [Fact]
    public void ShouldReturnChainOfResponsibility()
    {
        // Arrange
        _taxBands.Add(new TaxBandA());
        _taxBands.Add(new TaxBandB());
        _taxBands.Add(new TaxBandC());
        
        // Act
        var taxBandCalculatorHandler = _taxBandHandlerManager.CreateChainOfResponsibility(_taxBands);
        
        // Assert
        taxBandCalculatorHandler.Should().NotBeNull();
        taxBandCalculatorHandler.NextHandler.Should().NotBeNull();
        taxBandCalculatorHandler.NextHandler!.NextHandler.Should().NotBeNull();
        taxBandCalculatorHandler.NextHandler.NextHandler!.NextHandler.Should().BeNull();
    }
    
    [Fact]
    public void ShouldReturnOneHandlerForOneTaxBand()
    {
        // Arrange
        _taxBands.Add(new TaxBandA());
        
        // Act
        var taxBandCalculatorHandler = _taxBandHandlerManager.CreateChainOfResponsibility(_taxBands);
        
        // Assert
        taxBandCalculatorHandler.Should().NotBeNull();
        taxBandCalculatorHandler.NextHandler.Should().BeNull();
    }
    
    [Fact]
    public void ShouldThrowExceptionWhenTaxBandsAreNull()
    {
        // Arrange + Act
        var action = () => _taxBandHandlerManager.CreateChainOfResponsibility(null!);
        
        // Assert
        action.Should().Throw<ArgumentNullException>();
    }
    
    [Fact]
    public void ShouldThrowExceptionWhenThereAreNoTaxBands()
    {
        // Arrange + Act
        var action = () => _taxBandHandlerManager.CreateChainOfResponsibility(_taxBands);
        
        // Assert
        action.Should().Throw<ArgumentNullException>();
    }
}