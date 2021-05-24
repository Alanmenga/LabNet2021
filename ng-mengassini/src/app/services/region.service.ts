import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Region } from '../models/region';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RegionService {

  constructor(private http: HttpClient) { }

  postRegion(request: Region) {
    return this.http.post(environment.product + 'Region/', request);
  }
  putRegion(request: Region, id: number) {
    return this.http.put(environment.product + 'Region/' + id, request);
  }
  getRegion(id: number): Observable<Region> {
    return this.http.get<any>(environment.product + 'Region/' + id);
  }
  deleteRegion(id: number): Observable<Region> {
    return this.http.delete<any>(environment.product + 'Region/' + id);
  }
  getRegions(): Observable<Region[]> {
    return this.http.get<any>(environment.product + 'Region')
  }
}
