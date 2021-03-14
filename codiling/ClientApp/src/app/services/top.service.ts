import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { submission } from '../models/Submissions';

@Injectable({
  providedIn: 'root'
})
export class TopService {

  private submissionResults: submission[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any>(baseUrl + 'api/Submissions').subscribe(result => {
      this.submissionResults = result;
    }, error => console.error(error));
  }

  get top(): submission[] {
    return this.submissionResults;
  }
}
