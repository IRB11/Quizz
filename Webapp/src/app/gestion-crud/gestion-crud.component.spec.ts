import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionCrudComponent } from './gestion-crud.component';

describe('GestionCrudComponent', () => {
  let component: GestionCrudComponent;
  let fixture: ComponentFixture<GestionCrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GestionCrudComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GestionCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
