import { Observable } from "rxjs";

export interface GetByParamsInterface<T> {
    getByParams(params: Map<string, any>): Observable<T | never>;
}