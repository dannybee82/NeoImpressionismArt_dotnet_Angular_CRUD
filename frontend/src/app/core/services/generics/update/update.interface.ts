import { Observable } from "rxjs";

export interface UpdateInterface<T> {
    update(entity: T): Observable<void | never>;
    updateReturnEntity(entity: T): Observable<T | never>;
}