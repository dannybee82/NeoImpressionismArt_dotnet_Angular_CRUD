import { Observable } from "rxjs";

export interface CreateInterface<T> {
    create(entity: T): Observable<void | never>;
    createReturnEntity(entity: T): Observable<T | never>;    
}