import { inject, Injectable } from '@angular/core';
import { CreateInterface } from './create.interface';
import { Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { RESOURCE_CONFIG } from '../tokens/resource.config';
import { environment } from '../../../../../environments/environment';

@Injectable()
export class Create<T> implements CreateInterface<T> {

  private http = inject(HttpClient);
  private readonly config = inject(RESOURCE_CONFIG);  

  create(entity: T): Observable<void | never> {
    if(this.config.methodCreate?.controller && this.config.methodCreate.method) {
      return this.http.post<void>(`${environment.apiUrl}/${this.config.methodCreate.controller}/${this.config.methodCreate.method}`, entity);
    }

    return throwError(() => new Error(`Controller and or Method is not set.`));
  }

  createReturnEntity(entity: T): Observable<T | never> {
    if(this.config.methodCreate?.controller && this.config.methodCreate?.method) {
      return this.http.post<T>(`${environment.apiUrl}/${this.config.methodCreate.controller}/${this.config.methodCreate.method}`, entity);
    }

    return throwError(() => new Error(`Controller and or Method is not set.`));    
  }  
  
}