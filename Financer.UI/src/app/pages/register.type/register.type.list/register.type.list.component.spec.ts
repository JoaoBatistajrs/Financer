import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterTypeListComponent } from './register.type.list.component';

describe('RegisterTypeListComponent', () => {
  let component: RegisterTypeListComponent;
  let fixture: ComponentFixture<RegisterTypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegisterTypeListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RegisterTypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
