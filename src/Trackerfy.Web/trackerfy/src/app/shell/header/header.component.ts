import {Component, OnInit, OnDestroy, Inject} from '@angular/core';
import {DOCUMENT} from "@angular/common";
import {AuthService} from "../../auth/auth.service";

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
    if(this.auth.isLoggedIn) {
      this.auth.userProfile$.subscribe(user => {
        this.name = user.name;
        console.log(user)
      })
    }
  }

  ngOnDestroy() {
    // prevent memory leak when component is destroyed
  }
}
