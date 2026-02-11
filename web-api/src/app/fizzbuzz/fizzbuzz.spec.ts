import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Fizzbuzz } from './fizzbuzz';

describe('Fizzbuzz', () => {
  let component: Fizzbuzz;
  let fixture: ComponentFixture<Fizzbuzz>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Fizzbuzz]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Fizzbuzz);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
