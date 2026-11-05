import { HttpParams } from "@angular/common/http";

export abstract class SharedHttpParams {
 protected getHttpParams(params: Map<string, any>): HttpParams | undefined {
    if(params) {
      let p: HttpParams = new HttpParams();

      for (const [key, value] of Array.from(params.entries())) {
        p = p.append(key, value);
      }

      return p;
    }

    return undefined;
  }
}