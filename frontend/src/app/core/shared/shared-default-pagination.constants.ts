import { PaginatedData } from "../models/paginated-list/paginated-list.interface";

export const defaultPagination: PaginatedData = {
    currentPage: 1,
    from: 0,
    pageSize: 8,
    to: 0,
    totalCount: 0,
    totalPages: 0,
    hasPreviousPage: false,
    hasNextPage: false, 
  };