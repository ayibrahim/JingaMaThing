import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
export interface headers{}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  isnotLoggedIn: boolean = true;
  LoggingIn: boolean = false;
  SingingUp: boolean = false;
  data1: any;
  newdata : any[];
  selectedPhoto = null;
  public progress: number;
  public message: string;
  isImageLoading : boolean;
  imageToShow: any;
  constructor(private router: Router , private http : HttpClient) { }

  ngOnInit() {
    this.onSignIn();
  }
  onSignIn(){
    this.isnotLoggedIn = false;
    this.SingingUp = false;
    this.LoggingIn = true;
    // this.http.get('https://localhost:44380/api/userInfo').subscribe(
    //   (response : headers[] ) => {
    //     this.newdata = response;
    //     console.log(this.newdata);
    //   }, (error) => {console.log('error message ' + error)}
    // )
    //this.router.navigate(['./dashboard']);
  }
  onSignUp(){
    this.isnotLoggedIn = false;
    this.LoggingIn = false;
    this.SingingUp = true;
    
  }
  testing(files){
    this.selectedPhoto = files;
  }
//   createImageFromBlob(image: Blob) {
//     let reader = new FileReader();
//     reader.addEventListener("load", () => {
//        this.imageToShow = reader.result;
//     }, false);
 
//     if (image) {
//        reader.readAsDataURL(image);
//     }
//  }
//   getImage(): Observable<Blob> {
//     return this.http.get('https://localhost:44380/api/getPhoto', { responseType: 'blob' });
//   }
//   getImageFromService() {
//     this.isImageLoading = true;
//     this.getImage().subscribe(data => {
//       this.createImageFromBlob(data);
//       this.isImageLoading = false;
//     }, error => {
//       this.isImageLoading = false;
//       console.log(error);
//     });
// }
  upload(files) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', 'https://localhost:44380/api/upload/ayibra@hotmail.com/Customer' , formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response)
        this.message = event.body.toString();
    });
  } 
}
