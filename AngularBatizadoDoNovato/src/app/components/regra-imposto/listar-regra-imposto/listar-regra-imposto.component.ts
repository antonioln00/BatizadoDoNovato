import { Component } from '@angular/core';
import { RegraImposto } from '../../../models/regraImposto.model';
import { RegraImpostoService } from '../../../services/regra-imposto/regra-imposto.service';

@Component({
  selector: 'app-listar-regra-imposto',
  templateUrl: './listar-regra-imposto.component.html',
  styleUrl: './listar-regra-imposto.component.css',
})
export class ListarRegraImpostoComponent {
  regrasImposto: RegraImposto[];
  regraImposto: RegraImposto = {
    codigo: 0,
    nome: '',
    taxa: 0,
    produtos: [],
  };

  constructor(private _regraImpostoService: RegraImpostoService) {
    this.regrasImposto = [];
  }

  pesquisarRegraImposto() {
    this._regraImpostoService.get().subscribe({
      next: (jsonRegraImposto) => {
        let codigo = jsonRegraImposto.filter(
          (e) => e.codigo == this.regraImposto.codigo
        );

        if (this.regraImposto.codigo.toString() === '***') {
          this.regrasImposto = jsonRegraImposto;
        } else if (codigo.length != 0) {
          this.regrasImposto = codigo;
        } else {
          alert('Cadastro inexistente!');
        }
      },
    });
  }
}
