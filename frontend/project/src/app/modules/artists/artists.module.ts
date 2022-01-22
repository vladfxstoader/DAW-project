import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ArtistsRoutingModule } from './artists-routing.module';
import { ArtistsComponent } from './artists/artists.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ChildComponent } from './child/child.component';
import { ArtistComponent } from './artist/artist.component';
import { MarksPipe } from 'src/app/marks.pipe';

@NgModule({
  declarations: [
    ArtistsComponent,
    ChildComponent,
    ArtistComponent,
    MarksPipe
  ],
  imports: [
    CommonModule,
    ArtistsRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  exports: [
    MarksPipe,
  ]
})
export class ArtistsModule { }
