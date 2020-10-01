import { __awaiter } from "tslib";
import { TestBed } from '@angular/core/testing';
import { AuthCallbackComponent } from './auth-callback.component';
describe('AuthCallbackComponent', () => {
    let component;
    let fixture;
    beforeEach(() => __awaiter(void 0, void 0, void 0, function* () {
        yield TestBed.configureTestingModule({
            declarations: [AuthCallbackComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(AuthCallbackComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=auth-callback.component.spec.js.map