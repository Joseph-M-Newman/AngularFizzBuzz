import { TestBed } from '@angular/core/testing';

import { FizzBuzzApi } from './fizz-buzz-api';

describe('FizzBuzzApii', () => {
  let service: FizzBuzzApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FizzBuzzApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
