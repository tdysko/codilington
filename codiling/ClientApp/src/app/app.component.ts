import { Component, Inject } from '@angular/core';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    @Inject('environment') private environment: any
  ) {
    environment.baseURL = baseUrl;
  }
}
