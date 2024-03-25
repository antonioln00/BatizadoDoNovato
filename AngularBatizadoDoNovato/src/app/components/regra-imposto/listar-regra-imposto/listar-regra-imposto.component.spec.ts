import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarRegraImpostoComponent } from './listar-regra-imposto.component';

describe('ListarRegraImpostoComponent', () => {
  let component: ListarRegraImpostoComponent;
  let fixture: ComponentFixture<ListarRegraImpostoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListarRegraImpostoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListarRegraImpostoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
