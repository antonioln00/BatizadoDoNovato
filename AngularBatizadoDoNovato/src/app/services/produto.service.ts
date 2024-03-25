import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from '../models/produto.model';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private readonly _api = "http://localhost:5257/produto"

  constructor(private _http: HttpClient) {
   }

   get(): Observable<Produto[]>{
    return this._http.get<Produto[]>(this._api);
  }
}
