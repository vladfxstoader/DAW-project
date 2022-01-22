import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls: ['./songs.component.css']
})
export class SongsComponent implements OnInit {

  public songs = [];
  public displayedColumns = ['id','name','genre','duration','album.name','album.artist.name'];

  constructor(
    private router: Router,
    private songsService: SongsService
  ) { }

  ngOnInit(): void {
    this.songsService.getAllSongs().subscribe(
      (result) => {
        console.log(result);
        this.songs = result;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  public goToArtists(): void {
    this.router.navigate(['/artists']);
  }
}
