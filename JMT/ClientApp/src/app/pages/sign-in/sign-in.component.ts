import { Component, OnInit } from '@angular/core';
import { Globals } from '../../Shared/globals'
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';
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
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
  providers: [ Globals ] 
})
export class SignInComponent implements OnInit {
  constructor(public globals: Globals , private router : Router , private toastr: ToastrService , private http : HttpClient) { }
  Email: string; Password: string; errormessage: string; loginresponse: customer[]; developerlogin : Developer[];
  CFirstName : string; CLastName : string; CEmail2 : string; CPassword2: string; CustomerID : number; CPhoneNumber : string; CRoleDesc : string; CPhoto : string;
  DFirstName : string; DLastName : string; DEmail2 : string; DPassword2: string; DeveloperID : number; DPhoneNumber : string;  DPhoto: string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string;
  CnotD : string ; 
  regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
  ngOnInit() {
    this.Email = 'DShephard@Outlook.com';
    this.Password = 'Derek12345'
    this.Login();
  }
  Login(){
    if(!this.Email || !this.Password){
      this.toastr.clear();
      this.errormessage = '*Please Fill Out All Fields';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    var  serchfind:boolean;
    serchfind = this.regexp.test(this.Email);
    if(serchfind != true){
      this.toastr.clear();
      this.errormessage = '*Email Must be in Correct Format';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
          
    this.http.get('https://localhost:44380/api/getCustomerInfo/' + this.Email + '/' + this.Password)
     .subscribe(
         (response : customer[] ) => {
          this.loginresponse = response;
          if(this.loginresponse.length === 0){
            this.http.get('https://localhost:44380/api/getDeveloperInfo/' + this.Email + '/' + this.Password)
            .subscribe(
                    (response2 : Developer[] ) => { 
                      this.developerlogin = response2;
                      if(this.developerlogin.length === 0){
                        this.toastr.clear();
                        this.errormessage = '*Email or Password Incorrect. Try again!';
                        this.showNotification('top', 'center' , this.errormessage);
                      }else{
                        this.DFirstName = this.developerlogin[0].firstName;
                        this.DLastName = this.developerlogin[0].lastName;
                        this.DEmail2 = this.developerlogin[0].email;
                        this.DPassword2 = this.developerlogin[0].password;
                        this.DeveloperID = this.developerlogin[0].developerID;
                        this.DPhoneNumber = this.developerlogin[0].phoneNumber;
                        this.DDescription = this.developerlogin[0].description;
                        this.DPLanguages = this.developerlogin[0].pLanguages;
                        this.DSkills = this.developerlogin[0].skills;
                        this.DEducation = this.developerlogin[0].education;
                        this.DCertificates = this.developerlogin[0].certification;
                        this.DTitle = this.developerlogin[0].title;
                        this.DRoleDesc = this.developerlogin[0].roleDesc;
                        this.DPhoto = this.developerlogin[0].photo
                        this.CnotD = 'developer';
                        this.router.navigate(['./dashboard'], 
                        {state: {type: this.CnotD, FirstName: this.DFirstName , LastName: this.DLastName, PhoneNumber : this.DPhoneNumber , Email : this.DEmail2, Password : this.DPassword2
                        , Description : this.DDescription , PLanguages : this.DPLanguages , Skills : this.DSkills, Education : this.DEducation , Certification : this.DCertificates,
                          Title : this.DTitle , DeveloperID : this.DeveloperID , RoleDesc : this.DRoleDesc , Photo : this.DPhoto }});
                      }
                    }, (error) => {console.log('error message ' + error)}
                    )
          }else {
            this.CFirstName = this.loginresponse[0].firstName;
            this.CLastName = this.loginresponse[0].lastName;
            this.CEmail2 = this.loginresponse[0].email;
            this.CPassword2 = this.loginresponse[0].password;
            this.CustomerID = this.loginresponse[0].customerID;
            this.CPhoneNumber = this.loginresponse[0].phoneNumber;
            this.CRoleDesc = this.loginresponse[0].roleDesc;
            this.CPhoto = this.loginresponse[0].photo
            this.CnotD = 'customer';
            this.router.navigate(['./dashboard'], {state: {type: this.CnotD, FirstName: this.CFirstName , LastName: this.CLastName, PhoneNumber : this.CPhoneNumber , Email : this.CEmail2, Password : this.CPassword2 
              ,CustomerID : this.CustomerID ,RoleDesc : this.CRoleDesc , Photo : this.CPhoto}});
          }
          this.toastr.clear();
         }, (error) => {console.log('error message ' + error)}
       )
  }
  refresh(){
    window.location.reload();
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
