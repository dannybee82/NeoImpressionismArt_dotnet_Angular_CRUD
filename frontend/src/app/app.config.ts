import { ApplicationConfig, inject, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { routes } from './app.routes';
import { HttpEvent, HttpEventType, HttpHandlerFn, HttpRequest, provideHttpClient, withFetch, withInterceptors, withXhr } from '@angular/common/http';
import { finalize, Observable, tap } from 'rxjs';
import { Loading } from './core/services/loading/loading';

export function loadingInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> {
  const loadingService = inject(Loading);
  
  // Show loading spinner when request starts
  loadingService.isLoading.next(true);

  return next(req).pipe(
    tap(event => {
      // Hide loading spinner when response is received
      if (event.type === HttpEventType.Response || event.type === HttpEventType.User || event.type === HttpEventType.ResponseHeader) {
        loadingService.isLoading.next(false);
      }
    }),
    // Use finalize to ensure loading is hidden even if there's an error
    finalize(() => {
      loadingService.isLoading.next(false);
    })
  );
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes, withComponentInputBinding()),
    provideHttpClient(withXhr(), withInterceptors([loadingInterceptor]))
  ]
};
