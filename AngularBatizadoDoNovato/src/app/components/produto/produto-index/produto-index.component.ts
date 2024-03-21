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

  carregarProdutos = () => {
    console.log("está chegando aqui");
    this.produtoService.get().pipe(take(1)).subscribe({
      next: (jsonProduto:Produto[]) => {
        this.Produtos = jsonProduto
        console.log(this.Produtos);
      }
    })
  }
}