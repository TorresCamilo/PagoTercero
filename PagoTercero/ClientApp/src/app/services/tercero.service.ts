import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Tercero } from '../Tercero/models/tercero';

@Injectable({
  providedIn: "root",
})
export class TerceroService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Tercero[]> {
    /*let terceros: Tercero[] = [];
    terceros = JSON.parse(localStorage.getItem("datos"));*/

    return this.http.get<Tercero[]>(this.baseUrl + "api/tercero").pipe(
      tap(_ => console.log("Se consultaron los tercero satisfactoriamente")),
      catchError(error => {
        console.log("Error al consultar los datos")
        return of(error as Tercero[])
      })
    );
  }
  post(tercero: Tercero): Observable<Tercero> {
    /*let terceros: Tercero[] = [];
    let storageDatos = JSON.parse(localStorage.getItem("datos"));
    if (storageDatos != null) {
      terceros = storageDatos;
    }
    terceros.push(tercero);
    localStorage.setItem("datos", JSON.stringify(terceros));*/

    return this.http.post<Tercero>(this.baseUrl + "api/tercero", tercero).pipe(
      tap((_) => console.log("Se guardaron los tercero satisfactoriamente")),
      catchError((error) => {
        console.log("Error al registrar los datos");
        
        return of(error as Tercero);
      })
    );
  }
}
