import { Component, OnInit } from '@angular/core';
import { TerceroService } from 'src/app/services/tercero.service';
import { Tercero } from '../models/tercero';

@Component({
  selector: 'app-tercero-registro',
  templateUrl: './tercero-registro.component.html',
  styleUrls: ['./tercero-registro.component.css']
})
export class TerceroRegistroComponent implements OnInit {
  tercero: Tercero;
  constructor(private terceroService: TerceroService) { }

  ngOnInit() {
    this.tercero = new Tercero();
  }

  add() {
    this.terceroService.post(this.tercero).subscribe(t => {
      // console.log("Se agrego a "+t.nombre);
    });
  }
}
