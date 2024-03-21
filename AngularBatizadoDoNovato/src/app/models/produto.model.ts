import { RegraImposto } from "./regraImposto.model";

export class Produto {
    Codigo!: number;
    Nome: string;
    PrecoCusto: number;
    Markup: number;
    PrecoVenda: number;
    MargemReal: number;
    RegrasImposto: RegraImposto[];

    constructor() {
        this.Nome = '';
        this.PrecoCusto = 0.00;
        this.Markup = 0.00;
        this.PrecoVenda = 0.00;
        this.MargemReal = 0.00;
        this.RegrasImposto = []; 

    }

}