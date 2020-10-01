import { __decorate } from "tslib";
import { Component } from '@angular/core';
let IssueDetailsComponent = class IssueDetailsComponent {
    constructor(route, issuesService, usersService) {
        this.route = route;
        this.issuesService = issuesService;
        this.usersService = usersService;
        this.issue = {};
        this.route.params.subscribe(params => {
            this.issueId = params["issueId"];
            this.getIssue();
        });
        usersService.getAll().subscribe(result => {
            this.users = result;
        });
    }
    ngOnInit() {
    }
    getIssue() {
        this.issuesService.getIssueById(this.issueId).subscribe(result => {
            this.issue = result;
        });
    }
};
IssueDetailsComponent = __decorate([
    Component({
        selector: 'app-issue-details',
        templateUrl: './issue-details.component.html',
        styleUrls: ['./issue-details.component.sass']
    })
], IssueDetailsComponent);
export { IssueDetailsComponent };
//# sourceMappingURL=issue-details.component.js.map