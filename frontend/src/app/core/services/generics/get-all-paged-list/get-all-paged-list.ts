import { inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { RESOURCE_CONFIG } from '../tokens/resource.config';
import { environment } from '../../../../../environments/environment';
import { GetAllPagedListInterface } from './get-all-paged-list.interface';
import { PaginatedList } from '../../../models/paginated-list/paginated-list.interface';
import { SharedHttpParams } from '../shared/shared-http-params.abstract';

@Injectable()
export class GetAllPagedList<T> extends SharedHttpParams implements GetAllPagedListInterface<T> {
  private http = inject(HttpClient);
  private readonly config = inject(RESOURCE_CONFIG);  

  getAllPagedList(params: Map<string, any>): Observable<PaginatedList<T> | never> {
    if(this.config.methodGetAllPagedList?.controller && this.config.methodGetAllPagedList?.method) {
      const p: HttpParams | undefined = this.getHttpParams(params);  

      if(p) {
          return this.http.get<PaginatedList<T>>(
            `${environment.apiUrl}/${this.config.methodGetAllPagedList.controller}/${this.config.methodGetAllPagedList.method}`, 
            {params: p}
          );
      }
      
      return throwError(() => new Error(`Parameters are undefined`));
    }
    
    return throwError(() => new Error(`Controller and or Method is not set.`));
  }
  
}