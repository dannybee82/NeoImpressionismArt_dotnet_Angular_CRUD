import { Observable } from "rxjs";

export interface GetAllByParamsInterface<T> {
    getAllByParams(params: Map<string, any>): Observable<T[] | never>;
}