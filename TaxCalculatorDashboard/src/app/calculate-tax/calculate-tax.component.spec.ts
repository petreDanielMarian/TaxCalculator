import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculateTaxComponent } from './calculate-tax.component';

describe('CalculateTaxComponent', () => {
  let component: CalculateTaxComponent;
  let fixture: ComponentFixture<CalculateTaxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalculateTaxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CalculateTaxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
