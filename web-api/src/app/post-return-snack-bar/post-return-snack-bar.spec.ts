import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostReturnSnackBar } from './post-return-snack-bar';

describe('PostReturnSnackBar', () => {
  let component: PostReturnSnackBar;
  let fixture: ComponentFixture<PostReturnSnackBar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PostReturnSnackBar]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostReturnSnackBar);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
