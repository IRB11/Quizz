import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomQuizzesComponent } from './custom-quizzes.component';

describe('CustomQuizzesComponent', () => {
  let component: CustomQuizzesComponent;
  let fixture: ComponentFixture<CustomQuizzesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomQuizzesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomQuizzesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
