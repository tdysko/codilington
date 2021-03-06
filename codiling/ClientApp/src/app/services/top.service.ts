import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { submissionResult } from '../models/submissionResults';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TopService {

  constructor(@Inject('environment') private environment: any, private http: HttpClient) { }

  get(): Observable<submissionResult[]> {
    return this.http.get<submissionResult[]>(this.environment.baseUrl + 'api/SubmissionResults');
  }
}
