import { inject, Injectable } from '@angular/core';
import { DeleteByParamsInterface } from './delete-by-params.interface';
import { Observable, throwError } from 'rxjs';
import { SharedHttpParams } from '../shared/shared-http-params.abstract';
import { HttpClient, HttpParams } from '@angular/common/http';
import { RESOURCE_CONFIG } from '../tokens/resource.config';
import { environment } from '../../../../../environments/environment';

@Injectable()
export class DeleteByParams extends SharedHttpParams implements DeleteByParamsInterface {

  private http = inject(HttpClient);
  private readonly config = inject(RESOURCE_CONFIG);  

  delete(params: Map<string, any>): Observable<void | never> {
    if(this.config.methodDeleteByParams?.controller && this.config.methodDeleteByParams?.method) {
      const p: HttpParams | undefined = this.getHttpParams(params);

      if(p) {
        return this.http.delete<void>(
          `${environment.apiUrl}/${this.config.methodDeleteByParams.controller}/${this.config.methodDeleteByParams.method}`, 
          {params: p}
        );
      }

      return throwError(() => new Error(`Parameters are undefined`));
    } 
    
    return throwError(() => new Error(`Controller and or Method is not set.`));
  }
  
}