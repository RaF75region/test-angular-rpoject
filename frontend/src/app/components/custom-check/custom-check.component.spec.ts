import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomCheckComponent } from './custom-check.component';

describe('CustomCheckComponent', () => {
  let component: CustomCheckComponent;
  let fixture: ComponentFixture<CustomCheckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomCheckComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomCheckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
