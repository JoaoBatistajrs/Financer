import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpenseTypeDialogComponent } from './expense.type.dialog.component';

describe('ExpenseTypeDialogComponent', () => {
  let component: ExpenseTypeDialogComponent;
  let fixture: ComponentFixture<ExpenseTypeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExpenseTypeDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExpenseTypeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
