import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ArtistsService } from 'src/app/services/artists.service';
import { DataService } from 'src/app/services/data.service';
import { AddEditArtistComponent } from '../../shared/add-edit-artist/add-edit-artist.component';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.css']
})
export class ArtistsComponent implements OnInit, OnDestroy {

  public subscription!: Subscription;
  public loggedUser!: { username: string; password: string; };
  public parentMessage = 'message from parent';
  public artists = [];
  public displayedColumns =['id','name','yearOfBirth','manager.name','profile','delete'];

  constructor(
    private router: Router,
    private dataService: DataService,
    private artistsService: ArtistsService,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.subscription = this.dataService.currentUser.subscribe(user => this.loggedUser = user);
    this.artistsService.getArtists().subscribe(
      (result) => {
        console.log(result);
        this.artists = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }

  public logout(): void {
    localStorage.setItem('Role','Anonim');
    this.router.navigate(['/login']);
  }

  public goToSongs(): void {
    this.router.navigate(['/songs']);
  }

  public receiveMessage(event: any): void {
    console.log(event);
  }

  public deleteArtist(artist: any): void {
    this.artistsService.deleteArtist(artist.id).subscribe(
      (result) => {
        console.log(result);
        this.artistsService.getArtists().subscribe(
          (result) => {
            console.log(result);
            this.artists = result;
          },
          (error) => {
            console.error(error);
          }
        );
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public openModal(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    const dialogRef = this.dialog.open(AddEditArtistComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(
      (result) => {
        console.log(result);
        if (result) {
          this.artistsService.getArtists().subscribe(
            (result) => {
              console.log(result);
              this.artists = result;
            },
            (error) => {
              console.error(error);
            }
          );
        }
      }
    );
  }

  public addNewArtist(): void {
    this.openModal();
  }

  public goToArtistProfile(id: any): void {
    this.router.navigate(['/artist', id]);
  }

}
