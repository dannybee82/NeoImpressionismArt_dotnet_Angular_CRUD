import { inject, Injectable } from '@angular/core';
import { DeleteByIdInterface } from './delete-by-id.interface';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { RESOURCE_CONFIG } from '../tokens/resource.config';
import { environment } from '../../../../../environments/environment';

@Injectable()
export class DeleteById implements DeleteByIdInterface {
  
  private http = inject(HttpClient);
  private readonly config = inject(RESOURCE_CONFIG);  

  delete(id: number): Observable<void | never> {
    if(this.config.methodDeleteById?.controller && this.config.methodDeleteById?.method) {
      const params: HttpParams = new HttpParams().append('id', id);
      return this.http.delete<void>(
        `${environment.apiUrl}/${this.config.methodDeleteById.controller}/${this.config.methodDeleteById.method}`, 
        {params: params}
      );
    }

    return throwError(() => new Error(`Controller and or Method is not set.`));
  }
  
}
