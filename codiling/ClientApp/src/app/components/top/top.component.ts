import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TopService } from '../../services/top.service';

@Component({
  selector: 'app-top',
  templateUrl: './top.component.html'
})
export class TopComponent {
  public usersSubmissionsSummaries: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any>(baseUrl + 'api/Submissions').subscribe(result => {
      this.usersSubmissionsSummaries = result;
    }, error => console.error(error));
  }
}
