import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ThrowStmt } from '@angular/compiler';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
export interface headers{}
interface IServerCustomer {
  "customerID": number;
  "firstName": string;
  "lastName": string;
  "phoneNumber": string;
  "email": string;
  "password": string;
  "roleDesc": string;
}
export interface ICustomer {
  customerID: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  password: string;
  roleDesc: string;
}
@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  errormessage: string;
  newdata : any[];
  error : string;
  isCustomer: boolean = false;
  isStart : boolean = true;
  isDeveloper : boolean = false;
  isDeveloper2 : boolean = false;
  isDeveloper3 : boolean = false;
  CFirstName: string; CLastName: string; CPhoneNumber: number; CEmail: string; CPassword: string; CConfirmPassword: string;
  DFirstName: string; DLastName: string; DPhoneNumber: number; DEmail: string; DPassword: string; DConfirmPassword: string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string;
  regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
  CnotD : boolean = false;
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
     this.http.get('https://localhost:44380/api/InserNewCustomer/' + this.CFirstName + '/' + this.CLastName + '/' + this.CPhoneNumber + '/' + this.CEmail + '/' + this.CPassword)
     .subscribe(
         (response : headers[] ) => {
          this.newdata = response;
         }, (error) => {console.log('error message ' + error)}
       )
       this.toastr.clear();
       this.CnotD = true;
      this.router.navigate(['./dashboard'], {state: {type: this.CnotD, FirstName: this.CFirstName , LastName: this.CLastName, PhoneNumber : this.CPhoneNumber , Email : this.CEmail, Password : this.CPassword}});
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
    + '/' + this.DDescription + '/' + this.DPLanguages + '/' + this.DSkills + '/' + this.DEducation + '/' + this.DCertificates + '/' + this.DTitle)

    this.toastr.clear();
      this.CnotD = false;
      this.router.navigate(['./dashboard'], 
      {state: {type: this.CnotD, FirstName: this.DFirstName , LastName: this.DLastName, PhoneNumber : this.DPhoneNumber , Email : this.DEmail, Password : this.DPassword
      , Description : this.DDescription , PLanguages : this.DPLanguages , Skills : this.DSkills, Education : this.DEducation , Certification : this.DCertificates,
      Title : this.DTitle }});
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
    this.isStart = false;
    this.isDeveloper = false;
    this.isCustomer = false;
    this.isDeveloper2 = true;
    this.isDeveloper3 = false;
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
