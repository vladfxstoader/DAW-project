import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArtistsService {

  public url = 'https://localhost:5001/api/artist';
  

  constructor(
    public http: HttpClient
  ) { }

  public getArtists(): Observable<any> {
    return this.http.get(`${this.url}`);
  }

  public getArtistById(id: any): Observable<any>{
    return this.http.get(`${this.url}/${id}`);
  }

  public addArtist(artist:{name: any, yearOfBirth: any, manager: {name: any} }): Observable<any> {
    return this.http.post(`${this.url}`, artist);
  }

  public deleteArtist(id: any): Observable<any> {
    const url1 = this.url.concat('/').concat(id);
    return this.http.delete(`${url1}`, id);
  }
}
