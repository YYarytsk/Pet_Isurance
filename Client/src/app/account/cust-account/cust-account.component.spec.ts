import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustAccountComponent } from './cust-account.component';

describe('CustAccountComponent', () => {
  let component: CustAccountComponent;
  let fixture: ComponentFixture<CustAccountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustAccountComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
