var CreateIssueComponent_1;
import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { ModalDismissReasons } from "@ng-bootstrap/ng-bootstrap";
import { FormControl, FormGroup, Validators } from "@angular/forms";
let CreateIssueComponent = CreateIssueComponent_1 = class CreateIssueComponent {
    constructor(modalService, issueTypesService, issuesService, toastr, router) {
        this.modalService = modalService;
        this.issueTypesService = issueTypesService;
        this.issuesService = issuesService;
        this.toastr = toastr;
        this.router = router;
        this.newIssueForm = new FormGroup({
            issueTypeId: new FormControl('', Validators.required),
            summary: new FormControl('', Validators.required),
        });
    }
    open(content) {
        this.getIssueTypes();
        this.modalService.open(content, {
            ariaLabelledBy: 'Create new issue',
            size: "lg"
        }).result.then((result) => {
            this.closeResult = `Closed with: ${result}`;
        }, (reason) => {
            this.closeResult = `Dismissed ${CreateIssueComponent_1.getDismissReason(reason)}`;
        });
    }
    getIssueTypes() {
        this.issueTypesService.getIssueTypes().subscribe(result => {
            this.issueTypes = result;
        });
    }
    static getDismissReason(reason) {
        if (reason === ModalDismissReasons.ESC) {
            return 'by pressing ESC';
        }
        else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
            return 'by clicking on a backdrop';
        }
        else {
            return `with: ${reason}`;
        }
    }
    ngOnInit() {
    }
    createIssue() {
        if (this.newIssueForm.valid) {
            this.issuesService.create(this.newIssueForm.getRawValue()).subscribe((result) => {
                this.newIssueForm.reset();
                this.toastr.success("Issue was created successfully");
                this.goIssueDetail(result);
            });
        }
    }
    goIssueDetail(issueId) {
        this.router.navigate(["/issues/issue-detail/", issueId]);
    }
};
CreateIssueComponent = CreateIssueComponent_1 = __decorate([
    Component({
        selector: 'app-create-issue',
        templateUrl: './create-issue.component.html',
        styleUrls: ['./create-issue.component.sass']
    })
], CreateIssueComponent);
export { CreateIssueComponent };
//# sourceMappingURL=create-issue.component.js.map