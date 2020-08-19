import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { Dev } from 'src/app/layouts/admin-layout/admin-layout.component';
import {formatDate} from '@angular/common';
export interface headers{}
export interface customer{ 
  customerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; roleDesc : string; photo : string;
}
export interface Developer{
  developerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; description : string; pLanguages : string; skills : string; education : string; certification : string; title : string; roleDesc : string; photo : string;
}
export interface DevList{
  name : string; role : string; email : string;
}
export interface InsertNewOrder{
  CustomerID: string; DevEmail: string; OrderDesc: string; OrderRequirments: string; Budget: string; DateBy: string;
}
interface InsertNewOrders extends Array<InsertNewOrder>{}
@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css']
})
export class NewOrderComponent implements OnInit {
  retrievedID : string; retrievedRole : string;customerId : string;developerId : string; errormessage : String; selectedDev : DevList; newdata : headers[];
  iscustomer : boolean  = false; isdeveloper : boolean = false;
  CFirstName : string; CLastName : string; CEmail : string;  CustomerID : number; CPhoneNumber : string;  CPassword: string; CRoleDesc : string; CPhoto : any; CEmail2: string;
  DFirstName : string; DLastName : string; DEmail : string; DPassword: string; DeveloperID : number; DPhoneNumber : string; DPhoto : any; DEmail2 : string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string;
  developerlogin : Developer[]; loginresponse : customer[];
  OBudget :  number = 0.00; ODescription : string ; ORequirments : string; ODevList : DevList[]; ODateBy : string; currentdate : string; 
  constructor(private route: ActivatedRoute , private router : Router ,private http: HttpClient , private toastr: ToastrService) { }

  ngOnInit() {
    this.route.queryParams.subscribe((params=>{
      this.retrievedID = params.data;
      this.retrievedRole = params.data2;
      if(this.retrievedRole == 'Customer'){
        this.customerId = this.retrievedID;
      }
    }))
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
            this.GetDevList();
          }, (error) => {console.log('error message ' + error)}
          )
    }else {
      this.router.navigate(['./access-denied']);
    }
    this.currentdate = formatDate(new Date(), 'yyyy-MM-dd', 'en_US');
    
  }
  GetDevList(){
    this.http.get('https://localhost:44380/api/GetListofDevs').subscribe(
    (response : DevList[]) => {
      this.ODevList = response;
      console.log(this.ODevList);
      if(this.ODevList.length == 0){
        this.toastr.clear();
        this.errormessage = '*No Developers Exist';
        this.showNotification('top', 'center' , this.errormessage);
      }
    }, (error) => {this.toastr.clear();
      this.errormessage = 'Error Happened When Loading To ListBox , Refresh and Try Again!';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
  }
   onDate(ed){
     this.ODateBy = this.convert(this.ODateBy);
   }
  convert(str){
    var date = new Date(str),
    mnth = ("0" + (date.getMonth() + 1)).slice(-2),
    day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(),mnth , day].join("-");
  }
  SendOrder(){
    if(this.selectedDev == undefined || this.selectedDev == null || this.OBudget == 0 || !this.ODescription || !this.ORequirments || !this.ODateBy){
      this.toastr.clear();
      this.errormessage = '*Please Fill out all fields';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=>{    //<<<---    using ()=> syntax
        this.toastr.clear();
        }, 4000);
      return;
    }
    let date2 = formatDate(this.ODateBy , 'yyyy-MM-dd' , 'en_US');
    if(this.currentdate >= date2){
      this.toastr.clear();
      this.errormessage = '*Date Requested must be greater than ' + this.currentdate;
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=>{    //<<<---    using ()=> syntax
        this.toastr.clear();
        }, 4000);
      return;
    } 
    this.toastr.clear();
    var result: InsertNewOrders = [
      {  CustomerID: this.CustomerID.toString(), DevEmail : this.selectedDev.email.toString() , OrderDesc : this.ODescription.toString() , OrderRequirments : this.ORequirments.toString() 
        , Budget : this.OBudget.toString() , DateBy : this.ODateBy.toString() }
      ];
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }    
      
     this.http.post('https://localhost:44380/api/InsertNewOrder' , result[0] , httpOptions).subscribe(data => {
         console.log(data)
         this.toastr.clear();
         this.errormessage = 'Order Created Succesfully';
          this.showNotification('top', 'center' , this.errormessage);
        }, error => {
          this.toastr.clear();
          this.errormessage = 'Error Happened When Creating Order , Refresh and Try Again!';
          this.showNotification('top', 'center' , this.errormessage);
          console.log('error message ' + error)
     });
      setTimeout(()=>{    //<<<---    using ()=> syntax
        this.toastr.clear();
        }, 4000);
        this.selectedDev = undefined ;  this.selectedDev = null ; 
        this.OBudget = 0; this.ODateBy = undefined; this.ODateBy = null;
        this.ODescription = undefined; this.ODescription = null; 
        this.ORequirments = undefined; this.ORequirments = null;
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
