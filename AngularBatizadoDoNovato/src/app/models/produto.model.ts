import { RegraImposto } from "./regraImposto.model";

export class Produto {
    codigo!: number;
    nome: string;
    precoCusto: number;
    markup: number;
    precoVenda: number;
    margemReal: number;
    regrasImposto: RegraImposto[];

    constructor() {
        this.nome = '';
        this.precoCusto = 0.00;
        this.markup = 0.00;
        this.precoVenda = 0.00;
        this.margemReal = 0.00;
        this.regrasImposto = [];

    }

}
