import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ProdutoIndexComponent } from './components/produto/produto-index/produto-index.component';
import { ListarRegraImpostoComponent } from './components/regra-imposto/listar-regra-imposto/listar-regra-imposto.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CadastrarRegraImpostoComponent } from './components/regra-imposto/cadastrar-regra-imposto/cadastrar-regra-imposto.component';
import { BotaoProximoComponent } from './components/regra-imposto/listar-regra-imposto/botao-proximo/botao-proximo.component';
import { BotaoAnteriorComponent } from './components/regra-imposto/listar-regra-imposto/botao-anterior/botao-anterior.component';

@NgModule({
  declarations: [
    AppComponent,
    ProdutoIndexComponent,
    ListarRegraImpostoComponent,
    HeaderComponent,
    FooterComponent,
    CadastrarRegraImpostoComponent,
    BotaoProximoComponent,
    BotaoAnteriorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
