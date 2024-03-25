import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ProdutoIndexComponent } from './components/produto/produto-index/produto-index.component';
import { ListarRegraImpostoComponent } from './components/regra-imposto/listar-regra-imposto/listar-regra-imposto.component';

@NgModule({
  declarations: [
    AppComponent,
    ProdutoIndexComponent,
    ListarRegraImpostoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
