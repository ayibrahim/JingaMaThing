import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';

import { PhotoServiceService } from 'src/app/Shared/photo-service.service';
export interface headers{}
export interface customer{
  customerID : number;
  email : string;
  firstName : string;
  lastName : string;
  password : string;
  phoneNumber : string;
  roleDesc : string;
  photo : string;
}
export interface Developer{
  developerID : number;
  email : string;
  firstName : string;
  lastName : string;
  password : string;
  phoneNumber : string;
  description : string;
  pLanguages : string;
  skills : string;
  education : string;
  certification : string;
  title : string;
  roleDesc : string;
  photo : string;
}
@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  newdata : any[];
  errormessage : string;
  retrievedID : string;
  retrievedRole : string;
  customerId : string;
  developerId : string;
  developerlogin : Developer[]; loginresponse : customer[];
  iscustomer : boolean  = false;
  isdeveloper : boolean = false;
  CFirstName : string; CLastName : string; CEmail : string;  CustomerID : number; CPhoneNumber : string;  CPassword: string; CRoleDesc : string; CPhoto : any;
  DFirstName : string; DLastName : string; DEmail : string; DPassword: string; DeveloperID : number; DPhoneNumber : string; DPhoto : string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string;
  public progress: number; public message: string; isImageLoading : boolean; 
  regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
  images: any[];

    showThumbnails: boolean;

    fullscreen: boolean = false;

    activeIndex: number = 0;

    onFullScreenListener: any;

    // @ViewChild('galleria') galleria: Galleria;
  constructor(private route: ActivatedRoute , private router : Router , private http: HttpClient , private toastr: ToastrService , private photoService: PhotoServiceService) { }
  responsiveOptions:any[] = [
    {
        breakpoint: '1024px',
        numVisible: 5
    },
    {
        breakpoint: '768px',
        numVisible: 3
    },
    {
        breakpoint: '560px',
        numVisible: 1
    }
];
  ngOnInit( ) {
    this.route.queryParams.subscribe((params=>{
      this.retrievedID = params.data;
      this.retrievedRole = params.data2;
      if(this.retrievedRole == 'Customer'){
        this.customerId = this.retrievedID;
      }
      if(this.retrievedRole == 'Developer'){
        this.developerId = this.retrievedID;
      }
    }))
    console.log(this.customerId);
    console.log(this.developerId);
    // this.photoService.getImages().then(images => this.images = images);
    // this.bindDocumentListeners();
    if(this.customerId != undefined){
      this.iscustomer = true;
      this.http.get('https://localhost:44380/api/getCustomerInfoByID/' + this.customerId)
      .subscribe(
          (response : customer[] ) => {
           this.loginresponse = response;
           this.CFirstName = this.loginresponse[0].firstName;
            this.CLastName = this.loginresponse[0].lastName;
            this.CEmail = this.loginresponse[0].email;
            this.CPassword = this.loginresponse[0].password;
            this.CustomerID = this.loginresponse[0].customerID;
            this.CPhoneNumber = this.loginresponse[0].phoneNumber;
            this.CRoleDesc = this.loginresponse[0].roleDesc;
            this.CPhoto = this.loginresponse[0].photo;
          }, (error) => {console.log('error message ' + error)}
          )
    }
    if(this.developerId != undefined){
      this.isdeveloper = true;
      this.http.get('https://localhost:44380/api/getDeveloperInfoByID/' + this.developerId)
            .subscribe(
                    (response2 : Developer[] ) => { 
                      this.developerlogin = response2;
                        this.DFirstName = this.developerlogin[0].firstName;
                        this.DLastName = this.developerlogin[0].lastName;
                        this.DEmail = this.developerlogin[0].email;
                        this.DPassword = this.developerlogin[0].password;
                        this.DeveloperID = this.developerlogin[0].developerID;
                        this.DPhoneNumber = this.developerlogin[0].phoneNumber;
                        this.DDescription = this.developerlogin[0].description;
                        this.DPLanguages = this.developerlogin[0].pLanguages;
                        this.DSkills = this.developerlogin[0].skills;
                        this.DEducation = this.developerlogin[0].education;
                        this.DCertificates = this.developerlogin[0].certification;
                        this.DTitle = this.developerlogin[0].title;
                        this.DRoleDesc = this.developerlogin[0].roleDesc;
                        this.DPhoto = this.developerlogin[0].photo;
                    }, (error) => {console.log('error message ' + error)}
                    )
    }
  }
  CUploadPhoto(files) {
    if (files.length === 0){
      this.toastr.clear();
      this.errormessage = '*No File Chosen Update Failed.';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    this.toastr.clear();
    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', 'https://localhost:44380/api/upload/'+ this.CEmail + '/' + this.CRoleDesc , formData, {
      reportProgress: true,
    });
    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response)
        this.message = event.body.toString();
    });
    setTimeout(()=>{    //<<<---    using ()=> syntax
      this.getImageFromService();
 }, 1000);
    
  } 
    createImageFromBlob(image: Blob) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
       this.CPhoto = reader.result;
    }, false);
 
    if (image) {
       reader.readAsDataURL(image);
    }
 }
  getImage(): Observable<Blob> {
    return this.http.get('https://localhost:44380/api/GetProfileImageCustomer/' + this.CEmail, { responseType: 'blob' });
  }
  getImageFromService() {
    this.isImageLoading = true;
    this.getImage().subscribe(data => {
      this.createImageFromBlob(data);
      this.isImageLoading = false;
    }, error => {
      this.isImageLoading = false;
      console.log(error);
    });
}
  UpdateCustomerInfo(){
    if(!this.CFirstName|| !this.CLastName|| !this.CPhoneNumber || !this.CEmail){
      this.toastr.clear();
      this.errormessage = '*All Fields Must Have Value Before Updating';
      this.showNotification('top', 'center' , this.errormessage);
      return;
     }
     if(this.CPhoneNumber.toString().length != 10){
      this.toastr.clear();
      this.errormessage = '*Phone Number Must be 10 digits';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    var  serchfind:boolean;
    serchfind = this.regexp.test(this.CEmail);
    if(serchfind != true){
      this.toastr.clear();
      this.errormessage = '*Email Must be in Correct Format';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    this.http.get('https://localhost:44380/api/UpdateCustomerInfo/' + this.CustomerID + '/' + this.CFirstName + '/' + this.CLastName + '/' + this.CPhoneNumber + '/' + this.CEmail ).subscribe(
      (response2 : headers[]) => {
        this.newdata = response2
        console.log(this.newdata);
      }, (error) => {console.log('error message ' + error)}
      
    )
    this.toastr.clear();
    this.errormessage = '*Updated Successfully';
    this.showNotification('top', 'center' , this.errormessage);
    setTimeout(()=>{    //<<<---    using ()=> syntax
     this.toastr.clear();
 }, 5000);
  }
  showNotification(from, align , message){

    const color = Math.floor((Math.random() * 5) + 1);

    switch(color){
      case 1:
      this.toastr.info('<span class="tim-icons icon-bell-55" [data-notify]="icon"></span> <b>'+message+'</b>.', '', {
         disableTimeOut: true,
         closeButton: true,
         enableHtml: true,
         toastClass: "alert alert-info alert-with-icon",
         positionClass: 'toast-' + from + '-' +  align
       });
      break;
      case 2:
      this.toastr.success('<span class="tim-icons icon-bell-55" [data-notify]="icon"></span> <b>'+message+'</b>.', '', {
         disableTimeOut: true,
         closeButton: true,
         enableHtml: true,
         toastClass: "alert alert-success alert-with-icon",
         positionClass: 'toast-' + from + '-' +  align
       });
      break;
      case 3:
      this.toastr.warning('<span class="tim-icons icon-bell-55" [data-notify]="icon"></span> <b>'+message+'</b>.', '', {
         disableTimeOut: true,
         closeButton: true,
         enableHtml: true,
         toastClass: "alert alert-warning alert-with-icon",
         positionClass: 'toast-' + from + '-' +  align
       });
      break;
      case 4:
      this.toastr.error('<span class="tim-icons icon-bell-55" [data-notify]="icon"></span> <b>'+message+'</b>.', '', {
         disableTimeOut: true,
         enableHtml: true,
         closeButton: true,
         toastClass: "alert alert-danger alert-with-icon",
         positionClass: 'toast-' + from + '-' +  align
       });
       break;
       case 5:
       this.toastr.show('<span class="tim-icons icon-bell-55" [data-notify]="icon"></span> <b>'+message+'</b>.', '', {
          disableTimeOut: true,
          closeButton: true,
          enableHtml: true,
          toastClass: "alert alert-primary alert-with-icon",
          positionClass: 'toast-' + from + '-' +  align
        });
      break;
      default:
      break;
    }
  }
  UpdateDeveloperInfo(){
    if(!this.DEducation|| !this.DCertificates|| !this.DTitle || !this.DFirstName || !this.DLastName|| !this.DPhoneNumber|| !this.DEmail|| !this.DDescription|| !this.DPLanguages|| !this.DSkills){
      this.toastr.clear();
      this.errormessage = '*Please Fill Out All Fields';
      this.showNotification('top', 'center' , this.errormessage);
      return;
     }
     if(this.DPhoneNumber.toString().length != 10){
      this.toastr.clear();
      this.errormessage = '*Phone Number Must be 10 digits';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    var  serchfind:boolean;
    serchfind = this.regexp.test(this.DEmail);
    if(serchfind != true){
      this.toastr.clear();
      this.errormessage = '*Email Must be in Correct Format';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    this.http.get('https://localhost:44380/api/UpdateDeveloperInfo/' + this.DeveloperID + '/' + this.DFirstName + '/' + this.DLastName + '/' + this.DPhoneNumber + '/' 
    + this.DEmail + '/' + this.DTitle + '/' + this.DSkills + '/' +  this.DPLanguages + '/' + this.DEducation + '/' + this.DCertificates + '/' + this.DDescription ).subscribe(
      (response2 : headers[]) => {
        this.newdata = response2;
        console.log(this.newdata);
      }, (error) => {console.log('error message ' + error)}
      
    )
    this.toastr.clear();
    this.errormessage = '*Updated Successfully';
    this.showNotification('top', 'center' , this.errormessage);
    setTimeout(()=>{    //<<<---    using ()=> syntax
     this.toastr.clear();
 }, 5000);
  }


  DUploadPhoto(files) {
    if (files.length === 0){
      this.toastr.clear();
      this.errormessage = '*No File Chosen Update Failed.';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    this.toastr.clear();
    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', 'https://localhost:44380/api/upload/'+ this.DEmail + '/' + this.DRoleDesc , formData, {
      reportProgress: true,
    });
    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response)
        this.message = event.body.toString();
    });
    setTimeout(()=>{    //<<<---    using ()=> syntax
      this.DgetImageFromService();
 }, 1000);
    
  } 
    DcreateImageFromBlob(image: Blob) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
       this.CPhoto = reader.result;
    }, false);
 
    if (image) {
       reader.readAsDataURL(image);
    }
 }
  DgetImage(): Observable<Blob> {
    return this.http.get('https://localhost:44380/api/GetProfileImageDeveloper/' + this.DEmail, { responseType: 'blob' });
  }
  DgetImageFromService() {
    this.isImageLoading = true;
    this.DgetImage().subscribe(data => {
      this.DcreateImageFromBlob(data);
      this.isImageLoading = false;
    }, error => {
      this.isImageLoading = false;
      console.log(error);
    });
}
// onThumbnailButtonClick() {
//   this.showThumbnails = !this.showThumbnails;
// }

// toggleFullScreen() {
//   if (this.fullscreen) {
//       this.closePreviewFullScreen();
//   }
//   else {
//       this.openPreviewFullScreen();
//   }
// }

// openPreviewFullScreen() {
//   let elem = this.galleria.element.nativeElement.querySelector(".ui-galleria");
//   if (elem.requestFullscreen) {
//       elem.requestFullscreen();
//   }
//   else if (elem['mozRequestFullScreen']) { /* Firefox */
//       elem['mozRequestFullScreen']();
//   }
//   else if (elem['webkitRequestFullscreen']) { /* Chrome, Safari & Opera */
//       elem['webkitRequestFullscreen']();
//   }
//   else if (elem['msRequestFullscreen']) { /* IE/Edge */
//       elem['msRequestFullscreen']();
//   }
// }

// onFullScreenChange() {
//   this.fullscreen = !this.fullscreen;
// }

// closePreviewFullScreen() {
//   if (document.exitFullscreen) {
//       document.exitFullscreen();
//   }
//   else if (document['mozCancelFullScreen']) {
//       document['mozCancelFullScreen']();
//   }
//   else if (document['webkitExitFullscreen']) {
//       document['webkitExitFullscreen']();
//   }
//   else if (document['msExitFullscreen']) {
//       document['msExitFullscreen']();
//   }
// }

// bindDocumentListeners() {
//   this.onFullScreenListener = this.onFullScreenChange.bind(this);
//   document.addEventListener("fullscreenchange", this.onFullScreenListener);
//   document.addEventListener("mozfullscreenchange", this.onFullScreenListener);
//   document.addEventListener("webkitfullscreenchange", this.onFullScreenListener);
//   document.addEventListener("msfullscreenchange", this.onFullScreenListener);
// }

// unbindDocumentListeners() {
//   document.removeEventListener("fullscreenchange", this.onFullScreenListener);
//   document.removeEventListener("mozfullscreenchange", this.onFullScreenListener);
//   document.removeEventListener("webkitfullscreenchange", this.onFullScreenListener);
//   document.removeEventListener("msfullscreenchange", this.onFullScreenListener);
//   this.onFullScreenListener = null;
// }

// ngOnDestroy() {
//   this.unbindDocumentListeners();
// }

// galleriaClass() {
//   return `custom-galleria ${this.fullscreen ? 'fullscreen' : ''}`;
// }

// fullScreenIcon() {
//   return `pi ${this.fullscreen ? 'pi-window-minimize' : 'pi-window-maximize'}`;
// }
}
