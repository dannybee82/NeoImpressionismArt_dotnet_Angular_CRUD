import { TestBed } from '@angular/core/testing';
import { LoadFileInBrowser } from './load-file-in-browser';

describe('LoadFileInBrowser', () => {
  let service: LoadFileInBrowser;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoadFileInBrowser);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
