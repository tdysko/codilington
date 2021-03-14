import { Component, OnDestroy } from '@angular/core';
import { TopService } from '../../services/top.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-top',
  templateUrl: './top.component.html'
})
export class TopComponent implements OnDestroy {
  public usersSubmissionsSummaries: any;
  subscription: Subscription;

  constructor(private topservice: TopService) {
    this.subscription = this.topservice.get().subscribe(result => {
      this.usersSubmissionsSummaries = result;
    }, error => console.error(error));
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
