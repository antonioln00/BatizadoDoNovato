import { Produto } from "./produto.model";

export class RegraImposto {
    Codigo!: number;
    Nome: string;
    Taxa: number;
    Produtos: Produto[]

    constructor() {
        this.Nome = '';
        this.Taxa = 0.00;
        this.Produtos = [];
    }
}