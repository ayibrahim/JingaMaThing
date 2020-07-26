import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DevordersComponent } from './devorders.component';

describe('DevordersComponent', () => {
  let component: DevordersComponent;
  let fixture: ComponentFixture<DevordersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DevordersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DevordersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
