import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalculateTaxComponent } from "./calculate-tax/calculate-tax.component";
import { TaxCalculatorService } from "./services/tax-calculator.service";

@NgModule({
  declarations: [
    AppComponent,
    CalculateTaxComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule,
    FormsModule
  ],
  providers: [TaxCalculatorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
