import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Fizzbuzztable } from './fizzbuzztable';

describe('Fizzbuzztable', () => {
  let component: Fizzbuzztable;
  let fixture: ComponentFixture<Fizzbuzztable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Fizzbuzztable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Fizzbuzztable);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
