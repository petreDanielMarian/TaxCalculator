# TaxCalculator

Simple UK tax calculator based on 3 different tax bands.

## How to run:
### Start the backend server:
#### Method 1:
- Open the project in Visual Studio/Rider/Any other IDE that supports .Net development
- Build the project
- Run the app

#### Method 2:
- go to TaxCalculator\TaxCalculator (You should be in the folder that contains TaxCalculator.sln)
- open a cmd prompt
- run ```dotnet build```
- when build is finished, go to TaxCalculator (the project folder - it's a bit ocnfusing, I know, I found this out just now) and run ```dotnet run```

### Start the frontend client:
- go to TaxCalculator\TaxCalculatorDashboard
- open a cmd prompt
- run ```npm i```
- run ```ng serve```
- go to ```http://localhost:4200```

### Tech stack:
# Backend:
- .NetCore 6
- C# 10
- Swagger ui
- Newtonsoft.Json
# Unit testing:
- xUnit
- Moq
# Frontend
- Angular 13
- REST
