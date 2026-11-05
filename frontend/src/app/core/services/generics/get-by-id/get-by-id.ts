import { inject, Injectable } from '@angular/core';
import { GetByIdInterface } from './get-by-id.interface';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { RESOURCE_CONFIG } from '../tokens/resource.config';
import { environment } from '../../../../../environments/environment';

@Injectable()
export class GetById<T> implements GetByIdInterface<T> {
  private http = inject(HttpClient);
  private readonly config = inject(RESOURCE_CONFIG);  

  getById(id: number): Observable<T | never> {
    if(this.config.methodById?.controller && this.config.methodById?.method) {
      const params: HttpParams = new HttpParams().append('id', id);
      return this.http.get<T>(
        `${environment.apiUrl}/${this.config.methodById.controller}/${this.config.methodById.method}`, 
        {params: params}
      );
    }

    return throwError(() => new Error(`Controller and or Method is not set.`));
  }
  
}
