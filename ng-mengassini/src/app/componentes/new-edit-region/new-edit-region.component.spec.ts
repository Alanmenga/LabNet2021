import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewEditRegionComponent } from './new-edit-region.component';

describe('NewEditRegionComponent', () => {
  let component: NewEditRegionComponent;
  let fixture: ComponentFixture<NewEditRegionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewEditRegionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewEditRegionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
