import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { environment } from "../../environments/environment";
let UsersService = class UsersService {
    constructor(http) {
        this.http = http;
    }
    getAll() {
        return this.http.get(`${environment.apiUrl}/users`);
    }
};
UsersService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], UsersService);
export { UsersService };
//# sourceMappingURL=users.service.js.map