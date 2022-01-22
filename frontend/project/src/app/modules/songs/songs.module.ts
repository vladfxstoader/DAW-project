import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { SongsRoutingModule } from './songs-routing.module';
import { SongsComponent } from './songs/songs.component';


@NgModule({
  declarations: [
    SongsComponent
  ],
  imports: [
    CommonModule,
    SongsRoutingModule,
    MaterialModule,
  ]
})
export class SongsModule { }
