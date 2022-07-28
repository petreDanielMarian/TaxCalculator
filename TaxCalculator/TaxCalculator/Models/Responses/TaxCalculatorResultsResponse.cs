namespace TaxCalculator.Models.Responses;

public class TaxCalculatorResultsResponse
{
    public double GrossAnnualSalary {get; set;}
    public double GrossMonthlySalary {get; set;}
    public double AnnualTaxPaid { get; set; }
    public double MonthlyTaxPaid {get; set;}

    public double NetAnnualSalary =>
        Math.Round(GrossAnnualSalary - AnnualTaxPaid, Constants.Math.TwoDecimalsAproximation);

    public double NetMonthlySalary =>
        Math.Round(GrossMonthlySalary - MonthlyTaxPaid, Constants.Math.TwoDecimalsAproximation);
}