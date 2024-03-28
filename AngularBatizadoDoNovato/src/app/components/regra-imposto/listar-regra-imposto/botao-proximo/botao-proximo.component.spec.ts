import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BotaoProximoComponent } from './botao-proximo.component';

describe('BotaoProximoComponent', () => {
  let component: BotaoProximoComponent;
  let fixture: ComponentFixture<BotaoProximoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BotaoProximoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BotaoProximoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
