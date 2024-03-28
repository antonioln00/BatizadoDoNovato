import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-botao-anterior',
  templateUrl: './botao-anterior.component.html',
  styleUrl: './botao-anterior.component.css'
})
export class BotaoAnteriorComponent {
@Input() regrasAnteriores: boolean = false;
}
