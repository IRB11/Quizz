import { TestBed } from '@angular/core/testing';

import { RandomquizzService } from './randomquizz.service';

describe('RandomquizzService', () => {
  let service: RandomquizzService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RandomquizzService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
