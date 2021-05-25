import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TerceroService } from 'src/app/services/tercero.service';
import { Tercero } from '../models/tercero';

@Component({
  selector: "app-tercero-registro",
  templateUrl: "./tercero-registro.component.html",
  styleUrls: ["./tercero-registro.component.css"],
})
export class TerceroRegistroComponent implements OnInit {
  formGroup: FormGroup;
  tercero: Tercero;
  get control() {
    return this.formGroup.controls;
  }
  constructor(
    private terceroService: TerceroService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    this.buildForm();
  }
  private buildForm() {
    this.tercero = new Tercero();
    this.tercero.identificacion = "";
    this.tercero.nombre = "";
    this.tercero.telefono = "";
    this.formGroup = this.formBuilder.group({
      identificacion: [this.tercero.identificacion, [Validators.required, Validators.pattern("/\\d/")]],
      nombre: [this.tercero.nombre, Validators.required],
      telefono: [this.tercero.telefono, Validators.required],
    });
  }
  onSubmit() {
    if (!this.formGroup.invalid)
      this.add();
  }

  add() {
    this.tercero = this.formGroup.value;
    this.terceroService.post(this.tercero).subscribe((t) => {
      // console.log("Se agrego a "+t.nombre);
    });
  }
}
