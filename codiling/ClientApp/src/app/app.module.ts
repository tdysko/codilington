import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SolverComponent } from './components/solver/solver.component';
import { TopComponent } from './components/top/top.component';
import { EnumToArrayPipe } from './pipes/enumToArray';
import { environment } from '../environments/environment.prod';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SolverComponent,
    TopComponent,
    EnumToArrayPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'solver', component: SolverComponent },
      { path: 'top', component: TopComponent },
    ])
  ],
  providers: [{ provide: 'environment', useValue: environment }],
  bootstrap: [AppComponent],
  exports: [EnumToArrayPipe]
})
export class AppModule { }
