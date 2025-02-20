import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { firstValueFrom, from, throwError } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';
import { LoginResponse } from '../models/models';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

  const authService = inject(AuthService)

  const getCurrentUser = async (): Promise<LoginResponse | null> => {
    return await firstValueFrom(authService.currentUser$)
  };

  return from(getCurrentUser()).pipe(
    switchMap((currentUser) => {
      const authReq = currentUser
        ? req.clone({
            setHeaders: {
              Authorization: `Bearer ${currentUser.token}`,
            },
          })
        : req;

      return next(authReq).pipe(
        catchError((error) => {
          let errorMessage = 'Ha ocurrido un error inesperado.';

          if (error.error && error.error.message) {
            errorMessage = error.error.message;
          }
          switch (error.status) {
            case 401:
              authService.clearCurrentUser()
              break;
            case 400:
            case 403:
            case 404:
            case 409:
            case 500:
            case 422:
            case 0:
              break
          }

          alert(errorMessage)
          return throwError(() => new Error(errorMessage));
        })
      );
    })
  );
};
