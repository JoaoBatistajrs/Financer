import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterTypeDialogComponent } from './register.type.dialog.component';

describe('RegisterTypeDialogComponent', () => {
  let component: RegisterTypeDialogComponent;
  let fixture: ComponentFixture<RegisterTypeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegisterTypeDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RegisterTypeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
