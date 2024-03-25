import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarRegraImpostoComponent } from './components/regra-imposto/listar-regra-imposto/listar-regra-imposto.component';
import { ProdutoIndexComponent } from './components/produto/produto-index/produto-index.component';

const routes: Routes = [
  {
    path: 'regra-imposto/listar-regra-imposto',
    component: ListarRegraImpostoComponent
  },
  {
    path: 'produto/produto-index',
    component: ProdutoIndexComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
