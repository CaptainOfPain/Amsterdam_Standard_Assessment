import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SetProductStockModalComponent } from './set-product-stock-modal.component';

describe('SetProductStockModalComponent', () => {
  let component: SetProductStockModalComponent;
  let fixture: ComponentFixture<SetProductStockModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SetProductStockModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SetProductStockModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
