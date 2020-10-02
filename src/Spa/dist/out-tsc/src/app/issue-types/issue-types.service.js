import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let IssueTypesService = class IssueTypesService {
    constructor(http) {
        this.http = http;
        this.authApiURI = "http://localhost:5000/api";
    }
    getIssueTypes() {
        return this.http.get(this.authApiURI + '/issues/types');
    }
};
IssueTypesService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], IssueTypesService);
export { IssueTypesService };
//# sourceMappingURL=issue-types.service.js.map