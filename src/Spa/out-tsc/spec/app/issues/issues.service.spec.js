import { TestBed } from '@angular/core/testing';
import { IssuesService } from './issues.service';
describe('IssuesService', () => {
    let service;
    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(IssuesService);
    });
    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=issues.service.spec.js.map