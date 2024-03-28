import { Component } from '@angular/core';
import { RegraImposto } from '../../../models/regraImposto.model';
import { RegraImpostoService } from '../../../services/regra-imposto/regra-imposto.service';
import { Router } from '@angular/router';

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
  paragrafo: string = '';
  paginaAtual: number = 0;
  regrasAnteriores: boolean = false;
  maisRegras: boolean = true;

  constructor(
    private _regraImpostoService: RegraImpostoService,
    private _router: Router
  ) {
    this.regrasImposto = [];
  }

  ngOnInit(): void {}

  pesquisarRegraImposto() {
    if (!this.regraImposto.nome.trim()) {
      this.paragrafo = 'Nenhum resultado encontrado.';
      this.regrasImposto = [];
      return;
    }

    this._regraImpostoService.get(this.paginaAtual).subscribe({
      next: (jsonRegraImposto) => {
        let codigo = jsonRegraImposto.filter(
          (e) => e.codigo == this.regraImposto.codigo
        );

        let nome = jsonRegraImposto.filter((e) => {
          const lowerCaseNome = e.nome.toLowerCase();
          const lowerCaseTermo = this.regraImposto.nome.toLowerCase();

          return lowerCaseNome.includes(lowerCaseTermo);
        });

        if (codigo.length != 0) {
          this.regrasImposto = codigo;
          this.paragrafo = '';
        } else if (nome.length > 0) {
          this.regrasImposto = nome;
          this.paragrafo = '';
        } else if (this.regraImposto.nome.trim() === '***') {
          this.regrasImposto = jsonRegraImposto;
          this.paragrafo = '';
        } else {
          this.paragrafo = 'Nenhum resultado encontrado.';
        }
      },
    });
  }
}
