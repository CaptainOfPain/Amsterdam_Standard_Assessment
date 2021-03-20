import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveProductModalComponent } from './save-product-modal.component';

describe('SaveProductModalComponent', () => {
  let component: SaveProductModalComponent;
  let fixture: ComponentFixture<SaveProductModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SaveProductModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SaveProductModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
