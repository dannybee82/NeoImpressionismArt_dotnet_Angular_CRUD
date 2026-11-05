import { Observable } from "rxjs";

export interface DeleteByIdInterface {
    delete(id: number): Observable<void | never>;
}