import { TestBed } from '@angular/core/testing';

import { SectionDetailsService } from './section-details.service';

describe('SectionDetailsService', () => {
  let service: SectionDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SectionDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
