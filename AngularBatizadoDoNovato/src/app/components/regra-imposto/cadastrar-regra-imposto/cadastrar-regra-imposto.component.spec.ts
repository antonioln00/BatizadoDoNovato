import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarRegraImpostoComponent } from './cadastrar-regra-imposto.component';

describe('CadastrarRegraImpostoComponent', () => {
  let component: CadastrarRegraImpostoComponent;
  let fixture: ComponentFixture<CadastrarRegraImpostoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CadastrarRegraImpostoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CadastrarRegraImpostoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
