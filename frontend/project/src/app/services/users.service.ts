import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  public url = 'https://localhost:5001/api/user';
  constructor(
    public http: HttpClient
  ) { }
  public getAllUsers(): Observable<any>{
    return this.http.get(`${this.url}`);
  }
}
