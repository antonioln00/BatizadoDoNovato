// produto-index.component.ts
import { Component } from '@angular/core';
import { Produto } from '../../../models/produto.model';
import { ProdutoService } from '../../../services/produto/produto.service';

@Component({
  selector: 'app-produto-index',
  templateUrl: './produto-index.component.html',
  styleUrls: ['./produto-index.component.css'],
})
export class ProdutoIndexComponent {
  Produtos: Produto[];

  constructor(private produtoService: ProdutoService) {
    this.Produtos = [];
  }

  carregarProdutos() {
    this.produtoService.get().subscribe({
      next: (jsonProduto: Produto[]) => {
        this.Produtos = jsonProduto;
      },
    });
  }
}
