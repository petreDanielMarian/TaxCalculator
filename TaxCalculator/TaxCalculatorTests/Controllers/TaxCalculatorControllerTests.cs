using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaxCalculator.Controllers;
using TaxCalculator.Services.Interfaces;
using Xunit;

namespace TaxCalculatorTests.Controllers;

public class TaxCalculatorControllerTests
{
    private readonly TaxCalculatorController _controller;

    public TaxCalculatorControllerTests()
    {
        var taxCalculatorServiceMock = new Mock<ITaxCalculatorService>();
        taxCalculatorServiceMock.Setup(tcs => tcs.GetTaxFromSalary(It.IsAny<double>()))
            .Returns(600);
        
        taxCalculatorServiceMock.Setup(tcs => tcs.GetTaxFromSalary(0))
            .Throws<ArgumentNullException>();
        _controller = new TaxCalculatorController(taxCalculatorServiceMock.Object);
    }
    
    [Fact]
    public void TaxControllerShouldReturnCorrectTax()
    {
        // Arrange + Act
        var response = _controller.GetTaxes("8000").Value!;
        
        // Assert
        response.Should().NotBeNull();
        response.AnnualTaxPaid.Should().Be(600);
        response.MonthlyTaxPaid.Should().Be(50);
        response.GrossAnnualSalary.Should().Be(8000);
        response.GrossMonthlySalary.Should().Be(666.67);
        response.NetAnnualSalary.Should().Be(7400);
        response.NetMonthlySalary.Should().Be(616.67);
        response.ErrorMessage.Should().BeNull();
    }
    
    [Fact]
    public void TaxControllerShouldReturnErrorMessageWhenNoTaxBandIsApplied()
    {
        // Arrange + Act
        var response = _controller.GetTaxes("0").Value!;
        
        // Assert
        response.Should().NotBeNull();
        response.AnnualTaxPaid.Should().Be(0);
        response.MonthlyTaxPaid.Should().Be(0);
        response.GrossAnnualSalary.Should().Be(0);
        response.GrossMonthlySalary.Should().Be(0);
        response.NetAnnualSalary.Should().Be(0);
        response.NetMonthlySalary.Should().Be(0);
        response.ErrorMessage.Should().Be("No Tax bands were applied.");
    }
    
    [Fact]
    public void TaxControllerShouldReturnBadRequestInCaseOfSalaryNotBeingParsable()
    {
        // Arrange + Act
        var response = _controller.GetTaxes("N/A");
        
        // Assert
        response.Result.Should().BeOfType<BadRequestResult>();
    }
}