import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegraImposto } from '../../models/regraImposto.model';

@Injectable({
  providedIn: 'root',
})
export class RegraImpostoService {
  private readonly _api = 'http://localhost:5257/regraimposto';
  constructor(private _http: HttpClient) {}

  get(pagina: number): Observable<RegraImposto[]> {
    const itensPorPagina: number = 10;
    const url = `${this._api}/${pagina}/${itensPorPagina}`;

    return this._http.get<RegraImposto[]>(url);
  }

  getById(id: number): Observable<RegraImposto> {
    const url = `${this._api}/${id}`;
    return this._http.get<RegraImposto>(url);
  }
}
