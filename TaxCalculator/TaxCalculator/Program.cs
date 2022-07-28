using TaxCalculator;
using TaxCalculator.Containers;
using TaxCalculator.Services;
using TaxCalculator.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddRouting();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddCors();

// Add Services
builder.Services.AddSingleton<ITaxCalculatorService, TaxCalculatorService>();
builder.Services.AddSingleton<ITaxBandHandlerManager, TaxBandHandlerManager>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

var testClass = new TestClass();
testClass.Do();

app.Run();

namespace TaxCalculator
{
    public class TestClass
    {
        public void Do()
        {
            var taxBandCalculatorHandlerManager = new TaxBandHandlerManager();
            var taxAHandler = taxBandCalculatorHandlerManager.CreateChainOfResponsibility(TaxBandsContainer.GetTaxBandsAbc());

            var salary = 40000;
            var handleResult = taxAHandler.Handle(salary);
            Console.WriteLine($"------------ Tax is {handleResult} -----------");
            Console.ReadLine();
        }
    }
}

