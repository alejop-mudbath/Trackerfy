import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { switchMap } from "rxjs/operators";
let IssuesService = class IssuesService {
    constructor(http, auth) {
        this.http = http;
        this.auth = auth;
        this.authApiURI = "http://localhost:5000/api";
    }
    getAllIssues() {
        return this.auth.getTokenSilently.pipe(switchMap(token => this.http.get(`${this.authApiURI}/issues`, {
            headers: { Authorization: `Bearer ${token}` }
        })));
    }
    getIssuesStatistics() {
        return this.auth.getTokenSilently.pipe(switchMap(token => this.http.get(`${this.authApiURI}/issues/statistics`, {
            headers: { Authorization: `Bearer ${token}` }
        })));
    }
    getIssuesByState(stateId) {
        return this.auth.getTokenSilently.pipe(switchMap(token => this.http.get(`${this.authApiURI}/issues/state/${stateId}`, {
            headers: { Authorization: `Bearer ${token}` }
        })));
    }
    create(createIssue) {
        return this.http.post(`${this.authApiURI}/issues`, createIssue);
    }
    getIssueById(issueId) {
        return this.auth.getTokenSilently.pipe(switchMap(token => fetch(`${this.authApiURI}/issues/${issueId}`, {
            method: 'GET',
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(result => result.json())));
    }
};
IssuesService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], IssuesService);
export { IssuesService };
//# sourceMappingURL=issues.service.js.map