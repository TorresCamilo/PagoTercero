import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule} from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { TerceroRegistroComponent } from "./Tercero/tercero-registro/tercero-registro.component";
import { TerceroConsultaComponent } from "./Tercero/tercero-consulta/tercero-consulta.component";
import { PagoConsultaComponent } from "./Pago/pago-consulta/pago-consulta.component";
import { PagoRegistroComponent } from "./Pago/pago-registro/pago-registro.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TerceroRegistroComponent,
    TerceroConsultaComponent,
    PagoConsultaComponent,
    PagoRegistroComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(
      [
        { path: "", component: TerceroRegistroComponent, pathMatch: "full" },
        { path: "tercero/consulta", component: TerceroConsultaComponent },
        { path: "pago/registro", component: PagoRegistroComponent },
        { path: "pago/consulta", component: PagoConsultaComponent },
      ],
      { relativeLinkResolution: "legacy" }
    ),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
