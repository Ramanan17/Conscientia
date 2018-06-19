import { TestBed, inject } from '@angular/core/testing';

import { Services\dataService } from './services\data.service';

describe('Services\dataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [Services\dataService]
    });
  });

  it('should be created', inject([Services\dataService], (service: Services\dataService) => {
    expect(service).toBeTruthy();
  }));
});
