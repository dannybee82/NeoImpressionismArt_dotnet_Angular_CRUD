import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AllArtworks } from './all-artworks';

describe('AllArtworks', () => {
  let component: AllArtworks;
  let fixture: ComponentFixture<AllArtworks>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AllArtworks],
    }).compileComponents();

    fixture = TestBed.createComponent(AllArtworks);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
