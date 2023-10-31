import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SectionDetailsService {
  private sectionUrl = 'http://localhost:5208/api/section/';

  constructor(private http: HttpClient) { }

  getSection(id: any): Observable<any[]> {
    return this.http.get<any[]>(this.sectionUrl + id);
  }
}