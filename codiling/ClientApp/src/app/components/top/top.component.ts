import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TopService } from '../../services/top.service';

@Component({
  selector: 'app-top',
  templateUrl: './top.component.html'
})
export class TopComponent {
  public usersSubmissionsSummaries: any;

  constructor(private topservice: TopService) {
    console.log('top component');
    this.topservice.get().subscribe(result => {
      this.usersSubmissionsSummaries = result;
      console.log(this.usersSubmissionsSummaries);
    }, error => console.error(error));
  }
}
