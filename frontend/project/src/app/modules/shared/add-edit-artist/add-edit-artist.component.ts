import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ArtistsService } from 'src/app/services/artists.service';

@Component({
  selector: 'app-add-edit-artist',
  templateUrl: './add-edit-artist.component.html',
  styleUrls: ['./add-edit-artist.component.css']
})
export class AddEditArtistComponent implements OnInit {

  public artistForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    yearOfBirth: new FormControl(0),
    managerName: new FormControl('')
  });
  constructor(
    private artistsService: ArtistsService,
    public dialogRef: MatDialogRef<AddEditArtistComponent>,
  ) { }

  // getters
  get name(): AbstractControl | null {
    return this.artistForm.get('name');
  }
  get yearOfBirth(): AbstractControl | null {
    return this.artistForm.get('yearOfBirth');
  }
  get manager(): AbstractControl | null {
    return this.artistForm.get('manager');
  }

  ngOnInit(): void {
  }

  public addArtist(): void {
    const manager = {
      name: this.artistForm.value.managerName
    };
    const body = {
      name: this.artistForm.value.name,
      yearOfBirth: this.artistForm.value.yearOfBirth,
      manager: manager,
    };
    console.log(body);
    this.artistsService.addArtist(body).subscribe(
      (result) => {
        console.log(result);
        this.dialogRef.close(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

}
