import { Injectable, Inject } from '@angular/core';
import { codingChallenge } from '../models/Submissions';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CodingChallengesService {

  constructor(@Inject('environment') private environment: any, private http: HttpClient) { }

  get(): Observable<codingChallenge[]> {
    return this.http.get<codingChallenge[]>(this.environment.baseUrl + 'api/CodingChallenges');
  }
}
