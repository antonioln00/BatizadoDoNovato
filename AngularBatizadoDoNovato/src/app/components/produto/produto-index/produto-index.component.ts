// produto-index.component.ts
import { Component } from '@angular/core';
import { Produto } from '../../../models/produto.model';
import { ProdutoService } from '../../../services/produto.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-produto-index',
  templateUrl: './produto-index.component.html',
  styleUrls: ['./produto-index.component.css']
})
export class ProdutoIndexComponent{
  Produtos: Produto[];

  constructor(private produtoService: ProdutoService)
  {
    this.Produtos = [];
  }

  carregarProdutos() {
    console.log("Está chegando aqui");
    this.produtoService.get().subscribe({
      next: (jsonProduto: Produto[]) => {
        console.log("Dados recebidos:", jsonProduto); // Verificar se os dados foram recebidos corretamente
        this.Produtos = jsonProduto;
        console.log("Produtos após atribuição:", this.Produtos); // Verificar se os dados estão sendo atribuídos corretamente
      },
      error: (error) => {
        console.error("Erro ao carregar produtos:", error); // Exibir mensagens de erro, se houver
      }
    });
  }
}
