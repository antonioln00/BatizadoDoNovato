import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BotaoAnteriorComponent } from './botao-anterior.component';

describe('BotaoAnteriorComponent', () => {
  let component: BotaoAnteriorComponent;
  let fixture: ComponentFixture<BotaoAnteriorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BotaoAnteriorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BotaoAnteriorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
