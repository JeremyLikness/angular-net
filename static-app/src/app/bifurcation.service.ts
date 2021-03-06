import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

const BIFURC_URI: string = "https://localhost:5001/api/Bifurc";

@Injectable({
  providedIn: 'root'
})
export class BifurcationService {

  constructor(private http: HttpClient) {

   }

   getPoints(r: number, skip: number, iterations: number) {
     let params = new HttpParams()
      .set('skip', `${skip}`)
      .set('iterations', `${iterations}`);
     return this.http.get<number[]>(`${BIFURC_URI}/${r}/`, { params });
   }
}
