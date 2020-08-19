import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RmordersComponent } from './rmorders.component';

describe('RmordersComponent', () => {
  let component: RmordersComponent;
  let fixture: ComponentFixture<RmordersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RmordersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RmordersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
