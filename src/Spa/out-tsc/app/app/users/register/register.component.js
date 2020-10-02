import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { finalize } from "rxjs/operators";
let RegisterComponent = class RegisterComponent {
    constructor(authService) {
        this.authService = authService;
        this.userRegistration = { name: '', email: '', password: '' };
        this.submitted = false;
    }
    ngOnInit() {
    }
    onSubmit() {
        this.authService.register(this.userRegistration)
            .pipe(finalize(() => {
        }))
            .subscribe(() => {
            this.success = true;
        }, error => {
            this.error = error;
        });
    }
};
RegisterComponent = __decorate([
    Component({
        selector: 'app-register',
        templateUrl: './register.component.html',
        styleUrls: ['./register.component.sass']
    })
], RegisterComponent);
export { RegisterComponent };
//# sourceMappingURL=register.component.js.map