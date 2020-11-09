import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private loginPath = environment.apiUrl + '/Identity/Login';
  private registerPath = environment.apiUrl + '/Identity/Register';
  constructor(private http: HttpClient ) { }

  login(data): Observable<any> {
   return this.http.post(this.loginPath, data);
  }

  register(data): Observable<any>{
    return this.http.post(this.registerPath, data);
  }
}