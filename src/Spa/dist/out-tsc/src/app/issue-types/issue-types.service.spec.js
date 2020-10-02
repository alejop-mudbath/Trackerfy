import { TestBed } from '@angular/core/testing';
import { IssueTypesService } from './issue-types.service';
describe('IssueTypesService', () => {
    let service;
    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(IssueTypesService);
    });
    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=issue-types.service.spec.js.map