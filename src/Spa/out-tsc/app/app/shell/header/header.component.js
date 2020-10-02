import { __decorate, __param } from "tslib";
import { Component, Inject } from '@angular/core';
import { DOCUMENT } from "@angular/common";
let HeaderComponent = class HeaderComponent {
    constructor(document, auth) {
        this.document = document;
        this.auth = auth;
    }
    ngOnInit() {
        this.name = "";
        if (this.auth.isLoggedIn) {
            this.auth.userProfile$.subscribe(user => {
                this.name = user.name;
                console.log(user);
            });
        }
    }
    ngOnDestroy() {
        // prevent memory leak when component is destroyed
    }
};
HeaderComponent = __decorate([
    Component({
        selector: 'app-header',
        templateUrl: './header.component.html',
        styleUrls: ['./header.component.scss']
    }),
    __param(0, Inject(DOCUMENT))
], HeaderComponent);
export { HeaderComponent };
//# sourceMappingURL=header.component.js.map