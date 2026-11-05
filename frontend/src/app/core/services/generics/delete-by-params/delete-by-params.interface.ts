import { Observable } from "rxjs";

export interface DeleteByParamsInterface {
    delete(params: Map<string, any>): Observable<void | never>;
}