import { Observable } from "rxjs";
import { PaginatedList } from "../../../models/paginated-list/paginated-list.interface";

export interface GetAllPagedListInterface<T> {
  getAllPagedList(params: Map<string, any>): Observable<PaginatedList<T> | never> ;
}