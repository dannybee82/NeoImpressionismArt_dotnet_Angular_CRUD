import { Service } from '@angular/core';
import { defaultPagination } from '../../shared/shared-default-pagination.constants';
import { PaginatedData } from '../../models/paginated-list/paginated-list.interface';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

@Service()
export class PaginationStoreSimple {
    simplePaginationStore: BehaviorSubject<PaginatedData> = new BehaviorSubject<PaginatedData>(defaultPagination);
}
