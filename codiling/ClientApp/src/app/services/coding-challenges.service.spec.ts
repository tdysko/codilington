import { TestBed } from '@angular/core/testing';

import { CodingChallengesService } from './coding-challenges.service';

describe('CodingChallengesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CodingChallengesService = TestBed.get(CodingChallengesService);
    expect(service).toBeTruthy();
  });
});
