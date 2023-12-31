import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SectionService {
  private sectionsUrl = 'http://localhost:5208/api/section';

  constructor(private http: HttpClient) { }

  getSections(): Observable<any[]> {
    return this.http.get<any[]>(this.sectionsUrl);
  }
}