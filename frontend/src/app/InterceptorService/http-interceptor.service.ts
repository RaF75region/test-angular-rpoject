import { Injectable } from '@angular/core';
import {HttpClient, HttpEvent, HttpEventType, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Observable, switchMap, tap} from "rxjs";

@Injectable()
export class HttpInterceptorService implements HttpInterceptor {
  constructor(private http: HttpClient) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const defaultURL = "http://localhost:5230";

    console.log("Original URL: ", req.url);
    const modifiedReq = req.clone({
      url: req.url.startsWith('http') ? req.url : `${defaultURL}${req.url}`
    });

    console.log("Modified URL: ", modifiedReq.url);

    return next.handle(modifiedReq).pipe(
      tap(event => {
        if (event.type === HttpEventType.Response) {
          console.log(modifiedReq.url, `${req.url}`, event.status);
        }
      })
    );
  }
}
