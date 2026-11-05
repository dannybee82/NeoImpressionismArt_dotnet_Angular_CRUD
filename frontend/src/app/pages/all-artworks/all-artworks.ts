import { Component, inject, OnDestroy, OnInit, signal, WritableSignal } from '@angular/core';
import { PaginatedData, PaginatedList } from '../../core/models/paginated-list/paginated-list.interface';
import { Artwork } from '../../core/models/art/artwork.interface';
import { RESOURCE_CONFIG } from '../../core/services/generics/tokens/resource.config';
import { Observable } from 'rxjs/internal/Observable';
import { GetAllPagedList } from '../../core/services/generics/get-all-paged-list/get-all-paged-list';
import { AsyncPipe } from '@angular/common';
import { RouterModule } from '@angular/router';
import { environment } from '../../../environments/environment';
import { CustomPagination } from '../../core/components/custom-pagination/custom-pagination';
import { tap } from 'rxjs/internal/operators/tap';
import { PaginationStoreSimple } from '../../core/services/pagination/pagination-store-simple';
import { Subject, takeUntil } from 'rxjs';
import { defaultPagination } from '../../core/shared/shared-default-pagination.constants';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

// Material modules.
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  imports: [AsyncPipe, MatCardModule, MatButtonModule, MatIconModule, MatTooltipModule, RouterModule, CustomPagination],
  selector: 'app-all-artworks',
  styleUrl: './all-artworks.scss',
  templateUrl: './all-artworks.html',
  providers: [
    GetAllPagedList<PaginatedList<Artwork>>, 
    {
      provide: RESOURCE_CONFIG,
      useValue: {
        methodGetAllPagedList: { controller: 'Artwork', method: 'GetPagedList' }
      }
    }
  ],
})
export class AllArtworks implements OnInit, OnDestroy {

  private _lastPage: WritableSignal<number> = signal(1);
  private _lastPageSize: WritableSignal<number> = signal(10);
  protected artWorks$?: Observable<PaginatedList<Artwork>>;
  private readonly _apiurl = environment.apiUrl;
  private destroy$: Subject<void> = new Subject<void>();

  private readonly getAllPagedListService = inject(GetAllPagedList<PaginatedList<Artwork>>);
  private paginationStoreSimple = inject(PaginationStoreSimple);  
  protected paginationData: BehaviorSubject<PaginatedData> = new BehaviorSubject<PaginatedData>(
    this.paginationStoreSimple.simplePaginationStore.getValue() || defaultPagination
  );

  ngOnInit(): void {    
    this.paginationData.subscribe((paginationData: PaginatedData) => {
      if(this._lastPage() !== paginationData.currentPage || this._lastPageSize() !== paginationData.pageSize) {
        this._lastPage.set(paginationData.currentPage);
        this._lastPageSize.set(paginationData.pageSize);
        this.loadArtworks(paginationData);
      }      
    });

    if(!this.artWorks$) {      
      // No Artworks loaded at this point.
      this.loadArtworks(this.paginationData.getValue());
    }
  }

  ngOnDestroy(): void {
    this.paginationStoreSimple.simplePaginationStore.next(this.paginationData.getValue());
    this.destroy$.next();
  }

  getImageUrl(id: number | undefined): string {    
    return id ? `${this._apiurl}/Artwork/${id}` : '';
  }

  updatePagination($event: PaginatedData): void {
    const value: PaginatedData = this.paginationData.getValue();
    value.currentPage = $event.currentPage;
    value.pageSize = $event.pageSize;
    this.paginationData.next(value);
  }

  private loadArtworks(paginationData: PaginatedData): void {
    const params: Map<string, any> = new Map<string, any>([
      ['pageNumber', paginationData.currentPage],
      ['pageSize', paginationData.pageSize]      
    ]);
    this.artWorks$ = this.getAllPagedListService.getAllPagedList(params).pipe(      
      tap((data: PaginatedList<Artwork>) => {
        const pagiationData: PaginatedData = Object.assign(data);
        this.paginationData.next(pagiationData);          
      }),      
      takeUntil(this.destroy$)
    );
  }

}
