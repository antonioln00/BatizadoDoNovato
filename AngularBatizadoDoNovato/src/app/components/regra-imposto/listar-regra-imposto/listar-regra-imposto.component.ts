import { Component } from '@angular/core';
import { RegraImposto } from '../../../models/regraImposto.model';
import { RegraImpostoService } from '../../../services/regra-imposto/regra-imposto.service';
import { ActivatedRoute } from '@angular/router';

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

  constructor(
    private _regraImpostoService: RegraImpostoService,
    private _route: ActivatedRoute
  ) {
    this.regrasImposto = [];
  }

  pesquisarRegraImposto() {
    const id = this._route.snapshot.paramMap.get('id');

    if (this.regraImposto.codigo == parseInt(id!)) {
      this._regraImpostoService.getById(parseInt(id!)).subscribe({
        next: (jsonRegraImposto) => {
          this.regraImposto = jsonRegraImposto;
        },
      });
    } else if (this.regraImposto.codigo.toString() == '***') {
      this._regraImpostoService.get().subscribe({
        next: (jsonRegraImposto) => {
          this.regrasImposto = jsonRegraImposto;
        },
      });
    } else {
      alert("Cadastro inexistente!")
    }


  }

  testandoCodigo() {
    console.log(this.regraImposto.codigo);
  }
}
