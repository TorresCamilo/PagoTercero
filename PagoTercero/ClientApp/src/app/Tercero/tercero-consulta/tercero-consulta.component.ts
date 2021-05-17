import { Component, OnInit } from '@angular/core';
import { TerceroService } from 'src/app/services/tercero.service';
import { Tercero } from '../models/tercero';

@Component({
  selector: "app-tercero-consulta",
  templateUrl: "./tercero-consulta.component.html",
  styleUrls: ["./tercero-consulta.component.css"],
})
export class TerceroConsultaComponent implements OnInit {
  terceros: Tercero[];
  constructor(private terceroService: TerceroService) {}

  ngOnInit() {
    this.get();
  }
  get() {
    this.terceroService.get().subscribe(t => {
      this.terceros = t
    });
  }
}
