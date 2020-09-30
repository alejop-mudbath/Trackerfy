import {Component, OnInit, OnDestroy, Inject} from '@angular/core';
import { Subscription } from 'rxjs';
import {AuthService} from "@auth0/auth0-angular";
import {DOCUMENT} from "@angular/common";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {

  name: string;

  constructor(@Inject(DOCUMENT) public document: Document, public auth: AuthService) {}

  ngOnInit() {
    this.name = "";
  }

  ngOnDestroy() {
    // prevent memory leak when component is destroyed
  }
}
