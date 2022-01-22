import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ArtistsService } from 'src/app/services/artists.service';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.css']
})
export class ArtistComponent implements OnInit {

  public subscription: Subscription = new Subscription;
  public id: any;
  public artist = {
    name: 'default name',
    yearOfBirth: 0,
    manager: 'default name',
  };
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private artistsService: ArtistsService
  ) { }

  ngOnInit(): void {
    this.subscription = this.route.params.subscribe(params => {
      this.id = +params['id'];
      if (this.id) {
        this.getArtist();
      }
    });
  }

  public getArtist(): void {
    this.artistsService.getArtistById(this.id).subscribe(
      (result) => {
        console.log(result);
        const manager = result.manager.name;
        const body = {
          name: result.name,
          yearOfBirth: result.yearOfBirth,
          manager: manager,
        };
        this.artist = body;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public goToArtists(): void {
    this.router.navigate(['/artists']);
  }

}
