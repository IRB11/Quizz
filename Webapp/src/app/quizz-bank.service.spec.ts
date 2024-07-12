import { TestBed } from '@angular/core/testing';

import { QuizzBankService } from './quizz-bank.service';

describe('QuizzBankService', () => {
  let service: QuizzBankService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QuizzBankService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
