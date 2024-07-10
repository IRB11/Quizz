import { ComponentFixture, TestBed } from '@angular/core/testing';
import GeneratequizzComponent from './generatequizz.component';


describe('GeneratequizzComponent', () => {
  let component: GeneratequizzComponent;
  let fixture: ComponentFixture<GeneratequizzComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GeneratequizzComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GeneratequizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
