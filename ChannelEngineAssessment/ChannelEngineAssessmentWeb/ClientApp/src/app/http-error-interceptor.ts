import { Injectable } from '@angular/core';
import {
    HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import Swal from 'sweetalert2';
@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

    constructor() {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req)
            .pipe(
                catchError((error: HttpErrorResponse) => {
                    let errorMessage = `${error.error.message}`;
                    Swal.fire({
                        position: 'bottom-end',
                        icon: 'error',
                        title: errorMessage,
                        showConfirmButton: false,
                        timer: 1500
                      })
                    return throwError(errorMessage);
                }));
    }
}