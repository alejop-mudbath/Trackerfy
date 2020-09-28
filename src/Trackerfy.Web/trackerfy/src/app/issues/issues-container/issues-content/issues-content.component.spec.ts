import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IssuesContentComponent } from './issues-content.component';

describe('IssuesContentComponent', () => {
  let component: IssuesContentComponent;
  let fixture: ComponentFixture<IssuesContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IssuesContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IssuesContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
