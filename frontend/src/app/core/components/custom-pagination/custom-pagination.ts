import { Component, computed, input, InputSignal, OnInit, output, OutputEmitterRef, Signal, signal, viewChild, WritableSignal } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { PaginatedData } from '../../models/paginated-list/paginated-list.interface';
import { BehaviorSubject } from 'rxjs';
import { defaultPagination } from '../../shared/shared-default-pagination.constants';

// Material modules.
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-custom-pagination',
  imports: [MatPaginatorModule, MatButtonModule, MatIconModule],
  templateUrl: './custom-pagination.html',
  styleUrl: './custom-pagination.scss',
})
export class CustomPagination implements OnInit {
  readonly data: InputSignal<BehaviorSubject<PaginatedData>> =
    input.required<BehaviorSubject<PaginatedData>>();

  readonly emitUpdatePagination: OutputEmitterRef<PaginatedData> = output<PaginatedData>();

  // References to the paginator and sort components
  readonly paginator: Signal<MatPaginator> = viewChild.required<MatPaginator>(MatPaginator);

  private _defaultPagination: PaginatedData = defaultPagination;

  protected pagination: WritableSignal<PaginatedData> = signal(this._defaultPagination);
  protected pageSize: WritableSignal<number> = signal(25);

  protected disableFirstButton: Signal<boolean> = computed(() => {
    return this.pagination().hasPreviousPage
      ? this.pagination().currentPage === 1
        ? true
        : false
      : true;
  });

  protected disablePreviousButton: Signal<boolean> = computed(() => {
    return !this.pagination().hasPreviousPage;
  });

  protected disableNextButton: Signal<boolean> = computed(() => {
    return !this.pagination().hasNextPage;
  });

  protected disableLastButton: Signal<boolean> = computed(() => {
    return this.pagination().hasNextPage
      ? this.pagination().currentPage === this.pagination().totalPages
        ? true
        : false
      : true;
  });

  private _lastPage: Signal<number> = computed(() => {
    return this.pagination().totalPages;
  });

  ngOnInit(): void {
    this.data().subscribe((pagination: PaginatedData) => {
      this.pagination.set(pagination ? pagination : this._defaultPagination);
      this.setData();
    });
  }

  firstPage(): void {
    const data: PaginatedData = Object.assign(this.pagination());
    data.currentPage = 1;
    this.emitUpdatePagination.emit(data);
  }

  previousPage(): void {
    const data: PaginatedData = Object.assign(this.pagination());
    data.currentPage = data.currentPage - 1;
    this.emitUpdatePagination.emit(data);
  }

  nextPage(): void {
    const data: PaginatedData = Object.assign(this.pagination());
    data.currentPage = data.currentPage + 1;
    this.emitUpdatePagination.emit(data);
  }

  lastPage(): void {
    const data: PaginatedData = Object.assign(this.pagination());
    data.currentPage = this._lastPage();
    this.emitUpdatePagination.emit(data);
  }

  updatePagination(event: PageEvent): void {
    const data: PaginatedData = Object.assign(this.pagination());
    data.currentPage = 1;
    data.pageSize = event.pageSize;
    this.emitUpdatePagination.emit(data);
  }

  private setData(): void {
    this.paginator().length = this.pagination().totalCount;
    this.pagination().to =
      this.pagination().to < this.pagination().totalCount
        ? this.pagination().to
        : this.pagination().totalCount;
    this.pageSize.set(this.pagination().pageSize);
  }
}