import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SongsService {

  public url = 'https://localhost:5001/api/song';
  constructor(
    public http: HttpClient,

  ) { }

  public getAllSongs(): Observable<any> {
    return this.http.get(`${this.url}`);
  }
}
