import { TestBed } from '@angular/core/testing';
import { PaginationStoreSimple } from './pagination-store-simple';

describe('PaginationStoreSimple', () => {
  let service: PaginationStoreSimple;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PaginationStoreSimple);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
