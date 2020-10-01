import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { IssuesContainerComponent } from './issues-container.component';
describe('IssuesContainerComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [IssuesContainerComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(IssuesContainerComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=issues-container.component.spec.js.map