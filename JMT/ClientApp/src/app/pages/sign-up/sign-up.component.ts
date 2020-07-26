import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ThrowStmt } from '@angular/compiler';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
export interface headers{}
export interface test{ response : any;}
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
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  errormessage: string; CheckEmail : test[];
  newdata : any[];
  error : string;
  isCustomer: boolean = false;
  isStart : boolean = true;
  isDeveloper : boolean = false;
  isDeveloper2 : boolean = false;
  isDeveloper3 : boolean = false;
  CFirstName: string; CLastName: string; CPhoneNumber: string; CEmail: string; CPassword: string; CConfirmPassword: string; CustomerID : number;  CRoleDesc : String; CPhoto : string;
  DFirstName: string; DLastName: string; DPhoneNumber: string; DEmail: string; DPassword: string; DConfirmPassword: string; DeveloperID : number; DRoleDesc : string; DPhoto : string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; 
  loginresponse: customer[]; developerlogin : Developer[];
  regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
  CnotD : string;
  constructor(private toastr: ToastrService , private http : HttpClient , private router : Router) { }

  ngOnInit() {
  }
  CSubmit(){
    
    if(!this.CFirstName || !this.CLastName || !this.CPhoneNumber || !this.CEmail || !this.CPassword || !this.CConfirmPassword){
      this.toastr.clear();
      this.errormessage = '*Please Fill Out All Fields';
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
    if(this.CPassword.length < 8){
      this.toastr.clear();
      this.errormessage = '*Password Length Must be at least 8 characters';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    if(this.CPassword != this.CConfirmPassword){
      this.toastr.clear();
      this.errormessage = '*Password and Confirm Password Must Match';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    this.http.get('https://localhost:44380/api/CheckUserEmail/'+ this.CEmail).subscribe(
      (response2 : test[]) => {
        this.CheckEmail = response2;
      }, (error) => {console.log('error message ' + error)} 
    )
    setTimeout(()=>{
      if(this.CheckEmail[0].response == 'Found'){
          this.toastr.clear();
           this.errormessage = '*Email Already Exists , Try Signing up with a differnt email address.';
           this.showNotification('top', 'center' , this.errormessage);
           return;
      } else {
        this.http.get('https://localhost:44380/api/InserNewCustomer/' + this.CFirstName + '/' + this.CLastName + '/' + this.CPhoneNumber + '/' + this.CEmail + '/' + this.CPassword) .subscribe(
       (response2 : headers[]) => {
         this.newdata = response2;
         console.log(this.newdata);
       }, (error) => {console.log('error message ' + error)} 
     )

     setTimeout(()=>{    //<<<---    using ()=> syntax
      this.getCusotmerInfo();
      }, 1000);
      }
    }, 1000);
   
     
    
  }
  getCusotmerInfo(){
    this.http.get('https://localhost:44380/api/getCustomerInfo/' + this.CEmail + '/' + this.CPassword)
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
          this.toastr.clear();
          this.CnotD = 'customer';
          this.router.navigate(['./dashboard'], {state: {type: this.CnotD, FirstName: this.CFirstName , LastName: this.CLastName, PhoneNumber : this.CPhoneNumber ,
             Email : this.CEmail, Password : this.CPassword ,CustomerID : this.CustomerID ,RoleDesc : this.CRoleDesc , Photo : this.CPhoto}});
         }, (error) => {console.log('error message ' + error)}
       )
  }
  //Set on phone number fields so user cant enter a character such as the letter e or - only numbers.
  test(){
    if(this.CPhoneNumber == null){
      this.CPhoneNumber = undefined ;
    }
    if(this.DPhoneNumber == null){
      this.DPhoneNumber = undefined;
    }
  }
  //Final Submission on Developer Submit will validate last fields are all not empty and then insert record and redirect
  DSubmit(){
   if(!this.DEducation|| !this.DCertificates|| !this.DTitle){
    this.toastr.clear();
    this.errormessage = '*Please Fill Out All Fields';
    this.showNotification('top', 'center' , this.errormessage);
    return;
   }
   this.http.get('https://localhost:44380/api/InsertNewDeveloper/' + this.DFirstName + '/' + this.DLastName + '/' + this.DPhoneNumber + '/' + this.DEmail + '/' + this.DPassword
    + '/' + this.DDescription + '/' + this.DPLanguages + '/' + this.DSkills + '/' + this.DEducation + '/' + this.DCertificates + '/' + this.DTitle).subscribe(
      (response2 : headers[]) => {
        this.newdata = response2
        console.log(this.newdata);
      }, (error) => {console.log('error message ' + error)}
      
    )
    setTimeout(()=>{    //<<<---    using ()=> syntax
      this.getDeveloperInfo();
 }, 1000);
 
    
  }

  getDeveloperInfo(){
    this.http.get('https://localhost:44380/api/getDeveloperInfo/' + this.DEmail + '/' + this.DPassword)
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
      this.toastr.clear();
      this.CnotD = 'developer';
      this.router.navigate(['./dashboard'], 
      {state: {type: this.CnotD, FirstName: this.DFirstName , LastName: this.DLastName, PhoneNumber : this.DPhoneNumber , Email : this.DEmail, Password : this.DPassword
      , Description : this.DDescription , PLanguages : this.DPLanguages , Skills : this.DSkills, Education : this.DEducation , Certification : this.DCertificates,
        Title : this.DTitle , DeveloperID : this.DeveloperID , RoleDesc : this.DRoleDesc , Photo : this.DPhoto }});
    
    }, (error) => {console.log('error message ' + error)}
    )
  }
  refresh(){
    window.location.reload();
  }
  onCustomer(){
    this.isStart = false;
    this.isDeveloper = false;
    this.isCustomer = true;
    this.isDeveloper2 = false;
    this.isDeveloper3 = false;
  }
  onDeveloper(){
    this.isStart = false;
    this.isDeveloper = true;
    this.isCustomer = false;
    this.isDeveloper2 = false;
    this.isDeveloper3 = false;
  }
  ReturnToStart(){
    this.isStart = true;
    this.isDeveloper = false;
    this.isCustomer = false;
    this.isDeveloper2 = false;
    this.isDeveloper3 = false;
    this.toastr.clear();
    this.BackToStart();
  }
  SecondPageDev(){
    if( !this.DFirstName || !this.DLastName|| !this.DPhoneNumber|| !this.DEmail|| !this.DPassword|| !this.DConfirmPassword ){
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
      if(this.DPassword.length < 8){
        this.toastr.clear();
        this.errormessage = '*Password Length Must be at least 8 characters';
        this.showNotification('top', 'center' , this.errormessage);
        return;
      }
      if(this.DPassword != this.DConfirmPassword){
        this.toastr.clear();
        this.errormessage = '*Password and Confirm Password Must Match';
        this.showNotification('top', 'center' , this.errormessage);
        return;
      }
      this.http.get('https://localhost:44380/api/CheckUserEmail/'+ this.DEmail).subscribe(
        (response2 : test[]) => {
          this.CheckEmail = response2;
        }, (error) => {console.log('error message ' + error)} 
      )
      setTimeout(()=>{
        if(this.CheckEmail[0].response == 'Found'){
            this.toastr.clear();
             this.errormessage = '*Email Already Exists , Try Signing up with a differnt email address.';
             this.showNotification('top', 'center' , this.errormessage);
             return;
        } else {
          this.isStart = false;
          this.isDeveloper = false;
          this.isCustomer = false;
          this.isDeveloper2 = true;
          this.isDeveloper3 = false;
        }
      }, 1000);    
  }
  ThirdPageDev(){
    if(!this.DDescription|| !this.DPLanguages|| !this.DSkills){
      this.toastr.clear();
      this.errormessage = '*Please Fill Out All Fields';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    this.isStart = false;
    this.isDeveloper = false;
    this.isCustomer = false;
    this.isDeveloper2 = false;
    this.isDeveloper3 = true;
  }
  BacktoFirst(){
    this.isStart = false;
    this.isDeveloper = true;
    this.isCustomer = false;
    this.isDeveloper2 = false;
    this.isDeveloper3 = false;
  }
  BacktoSecond(){
    this.isStart = false;
    this.isDeveloper = false;
    this.isCustomer = false;
    this.isDeveloper2 = true;
    this.isDeveloper3 = false;
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
BackToStart(){
  this.CFirstName = undefined ; this.CLastName = undefined; this.CPhoneNumber = undefined; this.CEmail = undefined; this.CPassword = undefined; this.CConfirmPassword = undefined;
  this.DFirstName = undefined; this.DLastName = undefined; this.DPhoneNumber = undefined; this.DEmail = undefined; this.DPassword = undefined; this.DConfirmPassword = undefined;
  this.DDescription = undefined; this.DPLanguages = undefined; this.DSkills = undefined; this.DEducation = undefined; this.DCertificates = undefined; this.DTitle = undefined;
}
}
export interface CustomerSignUp {
  FirstName : string;
  LastName  :string;
  PhoneNumber : string;
  Email : string;
}
