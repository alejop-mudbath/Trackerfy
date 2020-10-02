import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { CreateIssueComponent } from './create-issue.component';
describe('CreateIssueComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [CreateIssueComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(CreateIssueComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=create-issue.component.spec.js.map