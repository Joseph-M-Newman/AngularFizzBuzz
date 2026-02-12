import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Sidebars } from './sidebars';

describe('Sidebars', () => {
  let component: Sidebars;
  let fixture: ComponentFixture<Sidebars>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Sidebars]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Sidebars);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
