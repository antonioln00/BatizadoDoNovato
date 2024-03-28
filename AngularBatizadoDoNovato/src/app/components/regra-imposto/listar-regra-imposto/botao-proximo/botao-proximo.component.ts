import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-botao-proximo',
  templateUrl: './botao-proximo.component.html',
  styleUrl: './botao-proximo.component.css'
})
export class BotaoProximoComponent {
@Input() maisRegras:boolean = false;
}
