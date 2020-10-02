import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import {FormsModule} from "@angular/forms";
import {UsersRoutingModule} from "./users.routing-module";
import {AuthModule} from "../auth/auth.module";

@NgModule({
  declarations: [RegisterComponent],
  imports: [
    CommonModule,
    FormsModule,
    UsersRoutingModule,
    AuthModule
  ],
  providers:[]
})
export class UsersModule { }
