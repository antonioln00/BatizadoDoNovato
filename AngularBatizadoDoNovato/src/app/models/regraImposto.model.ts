import { Produto } from "./produto.model";

export class RegraImposto {
    codigo!: number;
    nome: string;
    taxa: number;
    produtos: Produto[]

    constructor() {
        this.nome = '';
        this.taxa = 0.00;
        this.produtos = [];
    }
}
