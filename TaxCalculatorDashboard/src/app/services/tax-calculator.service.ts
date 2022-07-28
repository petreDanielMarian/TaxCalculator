import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';

import { TaxResult } from "../models/tax-result";

@Injectable()
export class TaxCalculatorService {
  baseUrl: string;

  constructor(private http: Http) {
    this.baseUrl = "https://localhost:7269/";
  }

  getTax(salary: number): Observable<TaxResult> {
    return this.http
        .get(this.baseUrl + `api/TaxCalculator/${salary}`)
        .pipe(map((response: any) => {
          console.log(response.json());

          return response.json() as TaxResult;
        }));
  }
}
