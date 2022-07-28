using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Models.Responses;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaxCalculatorController : ControllerBase
{
    private readonly ITaxCalculatorService _taxCalculatorService;

    public TaxCalculatorController(ITaxCalculatorService taxCalculatorService)
    {
        _taxCalculatorService = taxCalculatorService;
    }
    
    [HttpGet("{annualSalary}")]
    public ActionResult<TaxCalculatorResultsResponse> GetTaxes(string annualSalary)
    {
        if (!double.TryParse(annualSalary, out var salary))
        {
            return BadRequest();
        }

        var roundedSalary = Math.Round(salary, Constants.Math.TwoDecimalsAproximation);

        try
        {
            var taxPayed = Math.Round(_taxCalculatorService.GetTaxFromSalary(roundedSalary), Constants.Math.TwoDecimalsAproximation);
        
            return ComputeTaxCalculatorResponse(roundedSalary, taxPayed);
        }
        catch (ArgumentNullException)
        {
            return ComputeTaxCalculatorResponse(roundedSalary, 0, "No Tax bands were applied.");
        }
    }

    private static TaxCalculatorResultsResponse ComputeTaxCalculatorResponse(double roundedSalary, double taxPayed, string errorMessage = null!)
    {
        return new TaxCalculatorResultsResponse
        {
            GrossAnnualSalary = roundedSalary,
            GrossMonthlySalary = Math.Round(roundedSalary/Constants.TimePeriods.TwelveMonths, Constants.Math.TwoDecimalsAproximation),
            AnnualTaxPaid = taxPayed,
            MonthlyTaxPaid = Math.Round(taxPayed/Constants.TimePeriods.TwelveMonths, Constants.Math.TwoDecimalsAproximation),
            ErrorMessage = errorMessage
        };
    }
}