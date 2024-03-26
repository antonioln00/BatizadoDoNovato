import { Component } from '@angular/core';
import { RegraImposto } from '../../../models/regraImposto.model';
import { RegraImpostoService } from '../../../services/regra-imposto/regra-imposto.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastrar-regra-imposto',
  templateUrl: './cadastrar-regra-imposto.component.html',
  styleUrl: './cadastrar-regra-imposto.component.css'
})
export class CadastrarRegraImpostoComponent {
  regrasImposto: RegraImposto[] = [];
  regraImposto: RegraImposto = {
    codigo: 0,
    nome: '',
    taxa: 0,
    produtos: [],
  };

  constructor(
    private _regraImpostoService: RegraImpostoService,
    private _router: Router
  ) { }

  pesquisarRegraImpostoPorCodigo(){
    this._regraImpostoService.get().subscribe({
      next: (jsonRegraImposto) => {
        let codigo = jsonRegraImposto
          .filter(e => e.codigo == this.regraImposto.codigo);

          if (codigo.length != 0){
            this.regrasImposto = codigo;
            
          } else {
            alert("Cadastro inexistente!")
          }
      },
    });
  }
}
