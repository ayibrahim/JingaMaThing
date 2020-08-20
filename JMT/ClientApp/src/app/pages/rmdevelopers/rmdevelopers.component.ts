import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
export interface headers{}
export interface rmanager{ 
  resourceManagerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; roleDesc : string; photo : string;
}
export interface Developer{
  developerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; description : string; pLanguages : string; skills : string; education : string; certification : string; title : string; roleDesc : string; photo : string;
}
export interface Image{}
@Component({
  selector: 'app-rmdevelopers',
  templateUrl: './rmdevelopers.component.html',
  styleUrls: ['./rmdevelopers.component.css']
})
export class RmdevelopersComponent implements OnInit {
  retrievedID : string; retrievedRole : string; rmanagerId : any; isrmanager : boolean = false; rmresponse : rmanager[];
  RFirstName : string; RLastName : string; REmail2 : string; REmail : string; RPassword: string; ResourceManagerID : number; RPhoneNumber : string; RRoleDesc : string; RPhoto : any;
  DevList : any[];  nodevlist : boolean = true; errormessage : String;  newdata : headers[];
  DevList2 : any[];  nodevlist2 : boolean = true;
  DFirstName : string; DLastName : string; DEmail : string; DPassword: string; DeveloperID : number; DPhoneNumber : string; DPhoto : any; DEmail2 : string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string;
  developerlogin : Developer[]; images: any[]; isListofDevs : boolean = true;  gallerdisplay : boolean = false;  isdeveloper : boolean = false;
  DevHO : any[]; DevHOH : any[]; devselectedhoh: any; nodevhoh : boolean = true; i : number;
  constructor(private route: ActivatedRoute , private router : Router ,private http: HttpClient , private toastr: ToastrService) { }

  ngOnInit() {
    this.route.queryParams.subscribe((params=>{
      this.retrievedID = params.data;
      this.retrievedRole = params.data2;
      if(this.retrievedRole == 'ResourceManager'){
        this.rmanagerId = this.retrievedID;
      }
    }))
    
    if(this.rmanagerId != undefined){
      this.isrmanager = true;
      this.http.get('https://localhost:44380/api/GetResourceManagerInfoByID/' + this.rmanagerId)
      .subscribe(
          (response : rmanager[] ) => {
           this.rmresponse = response;
           this.RFirstName = this.rmresponse[0].firstName;
            this.RLastName = this.rmresponse[0].lastName;
            this.REmail = this.rmresponse[0].email;
            this.REmail2 = this.rmresponse[0].email;
            this.RPassword = this.rmresponse[0].password;
            this.ResourceManagerID = this.rmresponse[0].resourceManagerID;
            this.RPhoneNumber = this.rmresponse[0].phoneNumber;
            this.RRoleDesc = this.rmresponse[0].roleDesc;
            this.RPhoto = this.rmresponse[0].photo;
            this.GetDevListRM();
            this.GetDevListNotAssigned();
          }, (error) => {console.log('error message ' + error)}
          )
    } else {
      this.router.navigate(['./access-denied']);
    }
    
  }
  GetDevListRM(){
    this.http.get('https://localhost:44380/api/GetDevListRMDevelopers/' + this.ResourceManagerID).subscribe(
    (response : headers[]) => {
      this.DevList = response;
      if (this.DevList.length == 0){
        this.nodevlist = true;
      } else {
        this.nodevlist = false;
      }
    }, (error) => {this.nodevlist = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Dev List Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  AddToMyDevelopers(item){
    this.http.get('https://localhost:44380/api/AssignDevToRM/' + this.ResourceManagerID + '/' + item.developerID) .subscribe(
       (response2 : headers[]) => {
         this.newdata = response2;
         this.toastr.clear();
         this.errormessage = 'Added Succesfully';
          this.showNotification('top', 'center' , this.errormessage);
       }, (error) => {this.toastr.clear();
        this.errormessage = 'Error Happened When Adding Developer , Refresh and Try Again!';
        this.showNotification('top', 'center' , this.errormessage);
        console.log('error message ' + error)}
      )
    setTimeout(()=> this.GetDevListRM(), 2000);
    setTimeout(()=> this.GetDevListNotAssigned(), 2000);
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  GetDevListNotAssigned(){
    this.http.get('https://localhost:44380/api/GetDevNotAssignedToRM/' + this.ResourceManagerID).subscribe(
    (response : headers[]) => {
      this.DevList2 = response;
      if (this.DevList2.length == 0){
        this.nodevlist2 = true;
      } else {
        this.nodevlist2 = false;
      }
    }, (error) => {this.nodevlist2 = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Dev List Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  LoadDevProfile(event){
    const ID = event.value[0].developerID;
    console.log(ID);
    this.http.get('https://localhost:44380/api/getDeveloperInfoByID/' + ID)
            .subscribe(
                    (response2 : Developer[] ) => { 
                      this.developerlogin = response2;
                        this.DFirstName = this.developerlogin[0].firstName;
                        this.DLastName = this.developerlogin[0].lastName;
                        this.DEmail = this.developerlogin[0].email;
                        this.DEmail2 = this.developerlogin[0].email;
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
                        this.getImages(this.DeveloperID).then(images => this.images = images);
                        this.GetDevPastOrders(this.DeveloperID);
                        this.isListofDevs = false;
                        this.isdeveloper = true;
                        this.gallerdisplay = true;
                    }, (error) => {console.log('error message ' + error)}
                    )
  }
  GetDevPastOrders(ID)
  {
    this.http.get('https://localhost:44380/api/DevHistoryCustomerReview/' + ID).subscribe(
    (response : headers[]) => {
      this.DevHO = response;
      console.log(this.DevHO);
      if(this.DevHO.length == 0){
        this.nodevhoh = true;
        this.toastr.clear();
        this.errormessage = 'No Dev Order History Found.';
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.nodevhoh = false;
      }
      this.DevHOH = [];
      for (this.i = 0; this.i < this.DevHO.length; this.i++){
        for (var key in this.DevHO[this.i]){
          if(this.DevHOH.indexOf(key) === -1){
            if(key == 'orderNumber'){

            }else {
              this.DevHOH.push(key);
            }
          }
        }
      }   
    }, (error) => {this.nodevhoh = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Developers Orders History Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  testing2(){
    this.isdeveloper = false;
    this.gallerdisplay = false;
    this.GetDevListRM();
    this.isListofDevs = true;
  }
  getImages(devid : number) {
    return this.http.get<any>('https://localhost:44380/api/getDevGalleryInfo/'+ devid)
     .toPromise()
     .then(res => <Image[]>res)
     .then(data => { return data; });
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
}
