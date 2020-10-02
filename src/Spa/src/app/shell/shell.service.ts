import { Routes, Route } from '@angular/router';
import { ShellComponent } from './shell.component';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class Shell {

  static childRoutes(routes: Routes): Route {
    return {
      path: '',
      component: ShellComponent,
      children: routes,
      // =canActivate: [AuthenticationGuard],
      // Reuse ShellComponent instance when navigating between child views
      data: { reuse: true }
    };
  }
}
