import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {ShellModule} from "./shell/shell.module";
import {HttpClientModule} from "@angular/common/http";
import {UsersModule} from "./users/users.module";
import {IssuesModule} from "./issues/issues.module";

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ShellModule,
    HttpClientModule,
    UsersModule,
    IssuesModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
