import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
export interface Image{}
@Injectable({
  providedIn: 'root'
})
export class PhotoServiceService {

  constructor(private http : HttpClient) { }
  getImages(devid : number) {
     return this.http.get<any>('https://localhost:44380/api/getDevGalleryInfo/'+ devid)
      .toPromise()
      .then(res => <Image[]>res)
      .then(data => { return data; });
    }
}
