import { Component } from '@angular/core';
import { RegraImposto } from '../../../models/regraImposto.model';
import { RegraImpostoService } from '../../../services/regra-imposto/regra-imposto.service';

@Component({
  selector: 'app-listar-regra-imposto',
  templateUrl: './listar-regra-imposto.component.html',
  styleUrl: './listar-regra-imposto.component.css'
})
export class ListarRegraImpostoComponent {

  RegrasImposto: RegraImposto[];

  constructor(private _regraImpostoService: RegraImpostoService) {
    this.RegrasImposto = [];
  }

  pesquisarRegraImposto(){
    this._regraImpostoService.get().subscribe({
      next: ((jsonRegraImposto) => {
        this.RegrasImposto = jsonRegraImposto;
      })
    })

  }
}
