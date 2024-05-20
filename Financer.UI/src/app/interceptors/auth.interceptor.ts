import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  /** @todo set the auth token when we have the login service implemented */
  const authReq = req.clone({
    headers: req.headers.set('Authorization', 'TokenExample')
  });

  return next(authReq);
};
