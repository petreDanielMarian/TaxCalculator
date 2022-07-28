import { Component, OnInit } from '@angular/core';

import { TaxCalculatorService } from "../services/tax-calculator.service";
import { TaxResult } from "../models/tax-result";


@Component({
  selector: 'app-calculate-tax',
  templateUrl: './calculate-tax.component.html',
  styleUrls: ['./calculate-tax.component.css'],
  providers: [TaxCalculatorService]
})
export class CalculateTaxComponent implements OnInit {
  buttonPressed: boolean;
  taxResult : TaxResult;
  salary: number;

  constructor(private taxCalculatorService: TaxCalculatorService) {
  }

  ngOnInit(): void {
    this.resetView();
    this.taxResult = new TaxResult();
  }

  getTax(): void {
    if(this.salary <= 0) {
      window.alert("Annual salary must be greater than 0");
      this.resetView();
      return;
    }
    this.buttonPressed = true;
    this.taxCalculatorService
       .getTax(this.salary)
       .subscribe(result => this.taxResult = result);
  }

  resetView(): void {
    this.buttonPressed = false;
    this.salary = 0;
  }
}
