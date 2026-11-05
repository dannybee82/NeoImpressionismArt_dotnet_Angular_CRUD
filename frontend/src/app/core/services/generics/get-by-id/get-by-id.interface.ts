import { Observable } from "rxjs";

export interface GetByIdInterface<T> {
    getById(id: number): Observable<T | never>;
}