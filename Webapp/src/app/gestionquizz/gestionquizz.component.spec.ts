import { ComponentFixture, TestBed } from '@angular/core/testing';
import GestionquizzComponent from './gestionquizz.component';



describe('GestionquizzComponent', () => {
  let component: GestionquizzComponent;
  let fixture: ComponentFixture<GestionquizzComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GestionquizzComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GestionquizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
