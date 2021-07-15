import { TestBed } from '@angular/core/testing';

import { LirService } from './lir.service';

describe('LirService', () => {
  let service: LirService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LirService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
