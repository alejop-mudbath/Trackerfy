import { __decorate } from "tslib";
import { Component } from '@angular/core';
let IssuesContainerComponent = class IssuesContainerComponent {
    constructor(issuesService) {
        this.issuesService = issuesService;
        this.issueStatistics = [];
    }
    ngOnInit() {
        this.issuesService.getIssuesStatistics().subscribe(result => this.issueStatistics = result);
    }
};
IssuesContainerComponent = __decorate([
    Component({
        selector: 'app-issues-container',
        templateUrl: './issues-container.component.html',
        styleUrls: ['./issues-container.component.sass']
    })
], IssuesContainerComponent);
export { IssuesContainerComponent };
//# sourceMappingURL=issues-container.component.js.map