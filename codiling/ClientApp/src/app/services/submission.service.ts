import { Injectable, Inject } from '@angular/core';
import { submission } from '../models/Submissions';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubmissionService {

  constructor(@Inject('environment') private environment: any, private http: HttpClient) { }

  public postSubmission(submission: submission): Observable<any> {
    return this.http.post<submission>(this.environment.baseURL + 'api/Submissions', submission);
  }

  get(): Observable<submission[]> {
    return this.http.get<any>(this.environment.baseURL + 'api/Submissions');
  }

  runSubmission(submission: submission): Observable<any> {
    var to_compile = {
      "LanguageChoice": submission.Language,
      "Program": submission.Solution,
      "Input": "",
      "CompilerArgs": ""
    };

    return this.http.post<submission>('https://rextester.com/rundotnet/api', to_compile);
  }
}
