import { inject, Injectable } from '@angular/core';
import { GetByParamsInterface } from './get-by-params.interface';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { RESOURCE_CONFIG } from '../tokens/resource.config';
import { SharedHttpParams } from '../shared/shared-http-params.abstract';
import { environment } from '../../../../../environments/environment';

@Injectable()
export class GetByParams<T> extends SharedHttpParams implements GetByParamsInterface<T> {

  private http = inject(HttpClient);
  private readonly config = inject(RESOURCE_CONFIG);  

  getByParams(params: Map<string, any>): Observable<T | never> {
    if(this.config.methodByParams?.controller && this.config.methodByParams?.method) {
      const p: HttpParams | undefined = this.getHttpParams(params);

      if(p) {
        return this.http.get<T>(
          `${environment.apiUrl}/${this.config.methodByParams.controller}/${this.config.methodByParams.method}`,
          {params: p}
        );
      }

      return throwError(() => new Error(`Parameters are undefined`));
    }   

    return throwError(() => new Error(`Controller and or Method is not set.`));
  }
  
}
