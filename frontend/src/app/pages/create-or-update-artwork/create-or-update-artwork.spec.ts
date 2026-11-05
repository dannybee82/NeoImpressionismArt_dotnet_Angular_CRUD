import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CreateOrUpdateArtwork } from './create-or-update-artwork';

describe('CreateOrUpdateArtwork', () => {
  let component: CreateOrUpdateArtwork;
  let fixture: ComponentFixture<CreateOrUpdateArtwork>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateOrUpdateArtwork],
    }).compileComponents();

    fixture = TestBed.createComponent(CreateOrUpdateArtwork);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
