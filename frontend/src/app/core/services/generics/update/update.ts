import { inject, Service } from '@angular/core';
import { UpdateInterface } from './update.interface';
import { Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { RESOURCE_CONFIG } from '../tokens/resource.config';
import { environment } from '../../../../../environments/environment';

@Service()
export class Update<T> implements UpdateInterface<T> {

  private http = inject(HttpClient);
  private readonly config = inject(RESOURCE_CONFIG);  

  update(entity: T): Observable<void | never> {
    if(this.config.methodUpdate?.controller && this.config.methodUpdate?.method) {
      return this.http.put<void>(`${environment.apiUrl}/${this.config.methodUpdate.controller}/${this.config.methodUpdate.method}`, entity);
    }

    return throwError(() => new Error(`Controller and or Method is not set.`));
  }

  updateReturnEntity(entity: T): Observable<T | never> {
    if(this.config.methodUpdate?.controller && this.config.methodUpdate?.method) {
      return this.http.put<T>(`${environment.apiUrl}/${this.config.methodUpdate.controller}/${this.config.methodUpdate.method}`, entity);
    }

    return throwError(() => new Error(`Controller and or Method is not set.`));
  }
  
}