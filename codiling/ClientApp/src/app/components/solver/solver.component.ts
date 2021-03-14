import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EnumToArrayPipe } from '../../pipes/enumToArray';
import { codingChallenge, submission } from '../../models/Submissions';

@Component({
  selector: 'app-solver-component',
  providers: [EnumToArrayPipe],
  templateUrl: './solver.component.html'
})
export class SolverComponent {

  submission: submission = {
    Name: '',
    Solution: '',
    IdCodingChallenges: 0
  };
  codingChallenges: codingChallenge[];
  languages: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.http.get<codingChallenge[]>(this.baseUrl + 'api/CodingChallenges').subscribe(result => {
      console.log(result);
      this.codingChallenges = result;
    }, error => console.error(error));

    this.http.get<any>(this.baseUrl + 'api/Languages').subscribe(result => {
      console.log(result);
      this.languages = result;
    }, error => console.error(error));
  }

  submit() {
    this.http.post<submission>(this.baseUrl + 'api/Submissions', this.submission).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
    console.log(this.submission);
  }
}
