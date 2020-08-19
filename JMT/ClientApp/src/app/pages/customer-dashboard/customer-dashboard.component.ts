import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { SelectItem } from 'primeng';

export interface headers{}
export interface customer{ 
  customerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; roleDesc : string; photo : string;
}
export interface Developer{
  developerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; description : string; pLanguages : string; skills : string; education : string; certification : string; title : string; roleDesc : string; photo : string;
}
export interface Image{}
@Component({
  selector: 'app-customer-dashboard',
  templateUrl: './customer-dashboard.component.html',
  styleUrls: ['./customer-dashboard.component.css']
})
export class CustomerDashboardComponent implements OnInit {
  retrievedID : string; retrievedRole : string;customerId : string;developerId : string; errormessage : String;  newdata : headers[];
  iscustomer : boolean  = false; isdeveloper : boolean = false;
  CFirstName : string; CLastName : string; CEmail : string;  CustomerID : number; CPhoneNumber : string;  CPassword: string; CRoleDesc : string; CPhoto : any; CEmail2: string;
  DFirstName : string; DLastName : string; DEmail : string; DPassword: string; DeveloperID : number; DPhoneNumber : string; DPhoto : any; DEmail2 : string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string;
  developerlogin : Developer[]; loginresponse : customer[];
  DevList : any[];  nodevlist : boolean = true;
  images: any[]; isListofDevs : boolean = true;  gallerdisplay : boolean = false; 
  DevHO : any[]; DevHOH : any[]; devselectedhoh: any; nodevhoh : boolean = true; i : number;
  constructor(private route: ActivatedRoute , private router : Router ,private http: HttpClient , private toastr: ToastrService) { }

  ngOnInit() 
  {
    this.route.queryParams.subscribe((params=>{
      this.retrievedID = params.data;
      this.retrievedRole = params.data2;
      if(this.retrievedRole == 'Customer'){
        this.customerId = this.retrievedID;
      }
    }))
    if(this.retrievedRole == undefined){
      if(history.state.type == 'customer'){
        this.customerId = history.state.CustomerID;
      }
    }
    if(this.customerId != undefined){
      this.iscustomer = true;
      this.http.get('https://localhost:44380/api/getCustomerInfoByID/' + this.customerId)
      .subscribe(
          (response : customer[] ) => {
           this.loginresponse = response;
           this.CFirstName = this.loginresponse[0].firstName;
            this.CLastName = this.loginresponse[0].lastName;
            this.CEmail = this.loginresponse[0].email;
            this.CEmail2 = this.loginresponse[0].email;
            this.CPassword = this.loginresponse[0].password;
            this.CustomerID = this.loginresponse[0].customerID;
            this.CPhoneNumber = this.loginresponse[0].phoneNumber;
            this.CRoleDesc = this.loginresponse[0].roleDesc;
            this.CPhoto = this.loginresponse[0].photo;
            
          }, (error) => {console.log('error message ' + error)}
          )
    } else {
      this.router.navigate(['./access-denied']);
    }
    this.GetDevList();
  }

  GetDevList(){
    this.http.get('https://localhost:44380/api/GetDevListCustomerDashboard').subscribe(
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
  }
  testing2(){
    this.isdeveloper = false;
    this.gallerdisplay = false;
    this.GetDevList();
    this.isListofDevs = true;
  }
  LoadDevProfile(event){
    const ID = event.value[0].developerID;
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
        this.errormessage = '*No Dev Order History Found.';
        setTimeout(()=> this.toastr.clear(),3000);
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
      setTimeout(()=> this.toastr.clear(),3000);
      console.log('error message ' + error)}
    )
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
