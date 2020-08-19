import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RmdevelopersComponent } from './rmdevelopers.component';

describe('RmdevelopersComponent', () => {
  let component: RmdevelopersComponent;
  let fixture: ComponentFixture<RmdevelopersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RmdevelopersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RmdevelopersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
