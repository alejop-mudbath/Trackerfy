import { __awaiter, __decorate } from "tslib";
import { Component } from '@angular/core';
let IssuesListComponent = class IssuesListComponent {
    constructor(issuesServices, route) {
        this.issuesServices = issuesServices;
        this.route = route;
        this.issues = [];
        this.route.params.subscribe(params => {
            const stateId = params["stateId"];
            console.log(stateId);
            this.getIssues(stateId);
        });
    }
    ngOnInit() {
    }
    getIssues(statetId) {
        return __awaiter(this, void 0, void 0, function* () {
            let issues = this.issuesServices.getAllIssues();
            if (statetId)
                issues = this.issuesServices.getIssuesByState(statetId);
            issues.subscribe(result => {
                this.issues = result;
            });
        });
    }
};
IssuesListComponent = __decorate([
    Component({
        selector: 'app-issues-list',
        templateUrl: './issues-list.component.html',
        styleUrls: ['./issues-list.component.sass']
    })
], IssuesListComponent);
export { IssuesListComponent };
//# sourceMappingURL=issues-list.component.js.map