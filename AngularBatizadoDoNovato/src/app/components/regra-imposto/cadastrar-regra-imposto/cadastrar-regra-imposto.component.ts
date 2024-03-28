import { Component, HostListener } from '@angular/core';
import { RegraImposto } from '../../../models/regraImposto.model';
import { RegraImpostoService } from '../../../services/regra-imposto/regra-imposto.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastrar-regra-imposto',
  templateUrl: './cadastrar-regra-imposto.component.html',
  styleUrl: './cadastrar-regra-imposto.component.css',
})
export class CadastrarRegraImpostoComponent {
  regrasImposto: RegraImposto[] = [];
  regraImposto: RegraImposto = {
    codigo: 0,
    nome: '',
    taxa: 0,
    produtos: [],
  };
  paragrafo: string = '';

  constructor(
    private _regraImpostoService: RegraImpostoService,
    private _router: Router
  ) {}

  pesquisarRegraImpostoPorCodigo() {
    this._regraImpostoService.get().subscribe({
      next: (jsonRegraImposto) => {
        let codigo = jsonRegraImposto.filter(
          (e) => e.codigo == this.regraImposto.codigo
        );
        console.log(codigo);

        if (codigo.length > 0) {
          this.regrasImposto = codigo;
          this.paragrafo = '';
        } else {
          this.paragrafo = 'Cadastro inexistente.'
        }
      },
    });
  }

  onEnterKeyPressed(event: any) {
    event.preventDefault();
    this.pesquisarRegraImpostoPorCodigo();
  }

  pesquisa() {
    this._router.navigate(['regra-imposto/listarRegraImposto'])
  }

  @HostListener('document:keydown.f2', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    this.pesquisa();
  }
}
