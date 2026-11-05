import { inject, Injectable } from '@angular/core';
import { GetAllByParamsInterface } from './get-all-by-params.interface';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { RESOURCE_CONFIG } from '../tokens/resource.config';
import { environment } from '../../../../../environments/environment';
import { SharedHttpParams } from '../shared/shared-http-params.abstract';

@Injectable()
export class GetAllByParams<T> extends SharedHttpParams implements GetAllByParamsInterface<T> {
  private http = inject(HttpClient);
  private readonly config = inject(RESOURCE_CONFIG);  

  getAllByParams(params: Map<string, any>): Observable<T[] | never> {
    if(this.config.methodGetAllByParams?.controller && this.config.methodGetAllByParams?.method) {
      const p: HttpParams | undefined = this.getHttpParams(params);

      if(p) {
        return this.http.get<T[]>(
          `${environment.apiUrl}/${this.config.methodGetAllByParams.controller}/${this.config.methodGetAllByParams.method}`, 
          {params: p}
        );
      } 

      return throwError(() => new Error(`Parameters are undefined`));
    }

    return throwError(() => new Error(`Controller and or Method is not set.`));
  }
  
}
