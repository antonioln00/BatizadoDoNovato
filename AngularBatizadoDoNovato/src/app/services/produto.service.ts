import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from '../models/produto.model';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private url: string;

  constructor(private http: HttpClient) {
    this.url = "http://localhost:5257/produto";
   }

   get(): Observable<Produto[]>{
    return this.http.get<Produto[]>(this.url);
  }
}
