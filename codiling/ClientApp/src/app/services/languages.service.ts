import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LanguagesService {

  constructor(@Inject('environment') private environment: any, private http: HttpClient) { }

  get(): Observable<any> {
    return this.http.get<any>(this.environment.baseUrl + 'api/Languages');
  }
}
