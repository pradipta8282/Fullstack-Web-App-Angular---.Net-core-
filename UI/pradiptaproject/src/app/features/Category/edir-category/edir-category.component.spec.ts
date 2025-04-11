import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EdirCategoryComponent } from './edir-category.component';

describe('EdirCategoryComponent', () => {
  let component: EdirCategoryComponent;
  let fixture: ComponentFixture<EdirCategoryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EdirCategoryComponent]
    });
    fixture = TestBed.createComponent(EdirCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
