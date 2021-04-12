import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListEditSalesOrderComponent } from './list-edit-sales-order.component';

describe('ListEditSalesOrderComponent', () => {
  let component: ListEditSalesOrderComponent;
  let fixture: ComponentFixture<ListEditSalesOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListEditSalesOrderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListEditSalesOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
