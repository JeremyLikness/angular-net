import { TestBed, inject } from '@angular/core/testing';

import { BifurcationService } from './bifurcation.service';

describe('BifurcationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BifurcationService]
    });
  });

  it('should be created', inject([BifurcationService], (service: BifurcationService) => {
    expect(service).toBeTruthy();
  }));
});
