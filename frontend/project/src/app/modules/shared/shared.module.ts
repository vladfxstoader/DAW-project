import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEditArtistComponent } from './add-edit-artist/add-edit-artist.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HoverBtnDirective } from 'src/app/hover-btn.directive';
import { RegisterComponent } from './register/register.component';



@NgModule({
  declarations: [
    AddEditArtistComponent,
    HoverBtnDirective,
    RegisterComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  entryComponents: [
    AddEditArtistComponent,
    RegisterComponent
  ],
  exports: [
    HoverBtnDirective
  ]
})
export class SharedModule { }
