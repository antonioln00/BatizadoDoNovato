import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarRegraImpostoComponent } from './components/regra-imposto/listar-regra-imposto/listar-regra-imposto.component';
import { ProdutoIndexComponent } from './components/produto/produto-index/produto-index.component';
import { CadastrarRegraImpostoComponent } from './components/regra-imposto/cadastrar-regra-imposto/cadastrar-regra-imposto.component';

const routes: Routes = [
  {
    path: 'produto/produto-index',
    component: ProdutoIndexComponent
  },
  {
    path: 'regra-imposto/cadastrarRegraImposto',
    component: CadastrarRegraImpostoComponent
  },
  {
    path: 'regra-imposto/listar-regra-imposto',
    component: ListarRegraImpostoComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
