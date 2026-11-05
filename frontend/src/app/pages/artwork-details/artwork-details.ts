import { Component, effect, inject, input, InputSignal, OnInit, Signal, signal, viewChild, WritableSignal } from '@angular/core';
import { Artwork } from '../../core/models/art/artwork.interface';
import { catchError, EMPTY, map, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AsyncPipe } from '@angular/common';
import { YearsOfLifePipe } from '../../core/pipes/years-of-life.pipe';
import { RESOURCE_CONFIG } from '../../core/services/generics/tokens/resource.config';
import { GetById } from '../../core/services/generics/get-by-id/get-by-id';
import { BackToMainComponent } from '../../core/components/back-to-main/back-to-main.component';
import { ToastService } from '../../core/services/toast/toast-service';

// Angular Material modules.
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatAccordion, MatExpansionModule } from '@angular/material/expansion';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  imports: [AsyncPipe, YearsOfLifePipe, MatButtonModule, MatIconModule, MatAccordion, MatExpansionModule, MatTooltipModule, BackToMainComponent],
  selector: 'app-artwork-details',
  styleUrl: './artwork-details.scss',
  templateUrl: './artwork-details.html',
  providers: [
    GetById<Artwork>,
    {
      provide: RESOURCE_CONFIG,
      useValue: {        
        methodById: { controller: 'Artwork', method: 'GetById' }
      }
    }
  ]
})
export class ArtworkDetails implements OnInit {

  readonly id: InputSignal<number> = input.required<number>();
  readonly accordion: Signal<MatAccordion | undefined> = viewChild<MatAccordion | undefined>(MatAccordion);

  artwork$?: Observable<Artwork>;
  isPanelCollapsed: WritableSignal<boolean> = signal(false);
  private readonly _apiurl = environment.apiUrl;
  
  private readonly getByIdService = inject(GetById<Artwork>);
  private readonly toast = inject(ToastService);
  
  constructor() {
    effect(() => {
      if(this.accordion()) {
        this.accordion()!.openAll();
      }
    });
  }

  ngOnInit(): void {
    this.artwork$ = this.getByIdService.getById(this.id()).pipe(
      map((data: Artwork) => {
        if(!data) {
          throw new Error('No Data');
        }

        return data;
      }),
      catchError(() => {
        this.toast.show(`Error fetching Artwork`, 'error');
        return EMPTY;
      })
    );
  }

  getImageUrl(id: number | undefined): string {    
    return id ? `${this._apiurl}/Artwork/${id}` : '';
  }

  togglePanel(): void {
    this.isPanelCollapsed.set(!this.isPanelCollapsed());
  }

}
