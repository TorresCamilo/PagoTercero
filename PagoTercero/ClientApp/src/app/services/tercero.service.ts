import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Tercero } from '../Tercero/models/tercero';

@Injectable({
  providedIn: "root",
})
export class TerceroService {
  constructor() {}
  get(): Observable<Tercero[]> {
    let terceros: Tercero[] = [];
    terceros = JSON.parse(localStorage.getItem("datos"));

    return of(terceros).pipe(
      tap(_ => console.log("Se consultaron los tercero satisfactoriamente")),
      catchError(error => {
        console.log("Error al consultar los datos")
        return of(terceros)
      })
    );
  }
  post(tercero: Tercero) : Observable<Tercero>{
    let terceros: Tercero[] = [];
    let storageDatos = JSON.parse(localStorage.getItem("datos"));
    if (storageDatos != null) {
      terceros = storageDatos;
    }
    terceros.push(tercero);
    localStorage.setItem("datos", JSON.stringify(terceros));
    return of(tercero).pipe(
      tap(_ => console.log("Se guardaron los tercero satisfactoriamente")),
      catchError((error) => {
        console.log("Error al registrar los datos");
        return of(tercero);
      })
    );
  }
}
