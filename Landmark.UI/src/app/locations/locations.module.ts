import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { LocationFilterPipe } from "../pipes/location-filter.pipe";

import { LocationsComponent } from './locations.component';
import { MdInputModule, MdButtonModule, MdCardModule, MdDialogModule } from "@angular/material";
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { MapAddComponent } from "../map-add/map-add.component";

import { AgmCoreModule, MapsAPILoader } from "angular2-google-maps/core";

import { HttpModule } from '@angular/http';


@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    MdInputModule,
    MdButtonModule,
    MdDialogModule,
    MdCardModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', component: LocationsComponent }
    ]),
    AgmCoreModule.forRoot({ apiKey: 'AIzaSyAA6oETfpYm_1c-pLWktPlDNjD0YOTiYPM' })
  ],
  declarations: [LocationFilterPipe,
    MapAddComponent,
    LocationsComponent],
  entryComponents: [MapAddComponent],
  exports: [RouterModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class LocationsModule { }
