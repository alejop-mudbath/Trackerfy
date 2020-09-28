import {Component, OnInit, Output} from '@angular/core';
import {ModalDismissReasons, NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {IssueTypesService} from "../../issue-types/issue-types.service";
import {IssueTypeInterface} from "../../issue-types/issue-type.interface";
import {IssuesService} from "../issues.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ToastrService} from "ngx-toastr";
import {EventEmitter} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-create-issue',
  templateUrl: './create-issue.component.html',
  styleUrls: ['./create-issue.component.sass']
})
export class CreateIssueComponent implements OnInit {

  closeResult: string;
  issueTypes: IssueTypeInterface[];
  newIssueForm = new FormGroup({
    issueTypeId: new FormControl('', Validators.required),
    summary: new FormControl('', Validators.required),
  })


  constructor(private modalService: NgbModal,
              private issueTypesService: IssueTypesService,
              private issuesService: IssuesService,
              private toastr: ToastrService,
              private router: Router,) {

  }

  open(content) {
    this.getIssueTypes();

    this.modalService.open(content, {
      ariaLabelledBy: 'Create new issue',
      size: "lg"
    }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${CreateIssueComponent.getDismissReason(reason)}`;
    });
  }

  private getIssueTypes() {
    this.issueTypesService.getIssueTypes().subscribe(result => {
      this.issueTypes = result;
    })
  }

  private static getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  ngOnInit(): void {
  }

  createIssue() {
    if (this.newIssueForm.valid) {
      this.issuesService.create(this.newIssueForm.getRawValue()).subscribe((result) => {
        this.newIssueForm.reset();
        this.toastr.success("Issue was created successfully")
        this.goIssueDetail(result);
      })
    }
  }

  goIssueDetail(issueId) {
    this.router.navigate(["/issues/issue-detail/", issueId]);
  }

}
