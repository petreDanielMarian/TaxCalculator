using TaxCalculator;
using TaxCalculator.Models.TaxBands;
using TaxCalculator.Services;
using TaxCalculator.Services.Handlers;
using TaxCalculator.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddRouting();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddCors();

// Add Services
builder.Services.AddSingleton<ITaxCalculatorService, TaxCalculatorService>();

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

// app.MapGet("/", () => "Hello World!");

var testClass = new TestClass();
testClass.Do();

app.Run();

namespace TaxCalculator
{
    public class TestClass
    {
        public void Do()
        {
            var taxCHandler = new TaxBandCalculatorHandler(new TaxBandC());
            var taxBHandler = new TaxBandCalculatorHandler(new TaxBandB(), taxCHandler);
            var taxAHandler = new TaxBandCalculatorHandler(new TaxBandA(), taxBHandler);

            var salary = 8000;
            var handleResult = taxAHandler.Handle(salary);
            Console.WriteLine($"------------ Tax is {handleResult} -----------");
            Console.ReadLine();
        }
    }
}

