import { Observable } from "rxjs";

export interface GetAllInterface<T> {
    getAll(): Observable<T[] | never>;
}