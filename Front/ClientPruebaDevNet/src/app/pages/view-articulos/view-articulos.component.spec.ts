import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewArticulosComponent } from './view-articulos.component';

describe('ViewArticulosComponent', () => {
  let component: ViewArticulosComponent;
  let fixture: ComponentFixture<ViewArticulosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewArticulosComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewArticulosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
