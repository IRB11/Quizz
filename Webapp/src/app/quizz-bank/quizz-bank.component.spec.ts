import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizzBankComponent } from './quizz-bank.component';

describe('QuizzBankComponent', () => {
  let component: QuizzBankComponent;
  let fixture: ComponentFixture<QuizzBankComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QuizzBankComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QuizzBankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
