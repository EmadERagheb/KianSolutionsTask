import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoadingService } from '../_services/loading.service';
import { environment } from '../../environments/environment';
import { delay, finalize, identity } from 'rxjs';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const loadingService = inject(LoadingService);
  if (loadingService.excludeUrls.includes(req.url)) return next(req);
  loadingService.busy();
  
  console.log('loadingInterceptor');
  return next(req).pipe(
    !environment.production ? delay(1000) : identity,
    finalize(() => loadingService.idle())
  );
};
