import { inject, Injectable } from '@angular/core';
import { GetAllInterface } from './get-all.interface';
import { Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { RESOURCE_CONFIG } from '../tokens/resource.config';
import { environment } from '../../../../../environments/environment';

@Injectable()
export class GetAll<T> implements GetAllInterface<T> {

  private http = inject(HttpClient);
  private readonly config = inject(RESOURCE_CONFIG);  

  getAll(): Observable<T[] | never> {
    if(this.config.methodGetAll?.controller && this.config.methodGetAll?.method) {
      return this.http.get<T[]>(`${environment.apiUrl}/${this.config.methodGetAll.controller}/${this.config.methodGetAll.method}`);
    }
   
    return throwError(() => new Error(`Controller and or Method is not set.`));
  }
  
}