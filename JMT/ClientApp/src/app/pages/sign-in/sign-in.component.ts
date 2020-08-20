import { Component, OnInit } from '@angular/core';
import { Globals } from '../../Shared/globals'
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpClient, HttpHeaders } from '@angular/common/http';
export interface customer{
  customerID : number;email : string;firstName : string;lastName : string;password : string;phoneNumber : string;roleDesc : string;photo : string; sideBarColor : string; dashboardColor : string;
}
export interface rmanager{
  resourceManagerID : number;email : string;firstName : string;lastName : string;password : string;phoneNumber : string;roleDesc : string;photo : string; sideBarColor : string; dashboardColor : string;
}
export interface Developer{
  developerID : number; email : string;firstName : string;lastName : string;password : string;phoneNumber : string;description : string;pLanguages : string;skills : string;education : string;certification : string;title : string;roleDesc : string;photo : string; sideBarColor : string; dashboardColor : string;
}
export interface test{ response : any;}
export interface UpdaetPassword{
   Email: string; Password: string; 
}
interface UpdaetPasswords extends Array<UpdaetPassword>{}
@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
  providers: [ Globals ] 
})
export class SignInComponent implements OnInit {
  constructor(public globals: Globals , private router : Router , private toastr: ToastrService , private http : HttpClient) { }
  Email: string; Password: string; errormessage: string; loginresponse: customer[]; developerlogin : Developer[]; rmlogin : rmanager[];
  CFirstName : string; CLastName : string; CEmail2 : string; CPassword2: string; CustomerID : number; CPhoneNumber : string; CRoleDesc : string; CPhoto : string; CSideBarColor : string; CDashboardColor : string;
  RFirstName : string; RLastName : string; REmail2 : string; RPassword2: string; ResourceManagerID : number; RPhoneNumber : string; RRoleDesc : string; RPhoto : string; RSideBarColor : string; RDashboardColor : string;
  DFirstName : string; DLastName : string; DEmail2 : string; DPassword2: string; DeveloperID : number; DPhoneNumber : string;  DPhoto: string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string; DSideBarColor : string; DDashboardColor : string;
  CnotD : string ; isMainLogin : boolean = true; isForgotPassword : boolean = false; ForgotEmail : string;
  CheckEmail : test[]; CheckPassword : test[]; isEmailSentGood : boolean = false; isResetPassword : boolean = false;
  ResetEmail : string; OldPassword: string; NewPassword: string; ConfirmNewPassword: string; isPasswordResetGood : boolean = false;
  regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
  ngOnInit() {
    //Developer
     //this.Email = 'ayibrahi@hotmail.com';
     //this.Password = 'testing123'
    //this.Email = 'tes@ho.co';
    //this.Password = 'testing123'
    //Customer
     //this.Email = 'ryibrahim@something.com';
     //this.Password = 'testingtesting'

    // Resource Managers
    //this.Email = 'sjeong2@testing.net';
    //this.Password = 'testing123456';

    //this.Login();
  }
  
  ForgotPassword(){ this.isMainLogin = false; this.isForgotPassword = true; this.isEmailSentGood = false; this.ForgotEmail = undefined; }
  ResetPassword(){ this.isMainLogin = false; this.isResetPassword = true; this.isPasswordResetGood = false; this.ResetEmail = undefined;
  this.OldPassword = undefined; this.NewPassword = undefined; this.ConfirmNewPassword = undefined; }
  SubmitForgotPassword(){
    if(!this.ForgotEmail ){
      this.toastr.clear();
      this.errormessage = '*Please Enter an Email Address';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    var  serchfind:boolean;
    serchfind = this.regexp.test(this.ForgotEmail);
    if(serchfind != true){
      this.toastr.clear();
      this.errormessage = '*Email Must be in Correct Format';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    this.http.get('https://localhost:44380/api/CheckUserEmail/'+ this.ForgotEmail).subscribe(
        (response2 : test[]) => {
          this.CheckEmail = response2;
        }, (error) => {console.log('error message ' + error)} 
      )
      setTimeout(()=>{
        if(this.CheckEmail[0].response == 'Found'){
          this.http.get('https://localhost:44380/api/SendForgotPasswordEmail/'+ this.ForgotEmail).subscribe(
            (response2 : test[]) => {
              this.CheckEmail = response2;
              this.isEmailSentGood = true;
            }, (error) => {console.log('error message ' + error)} 
          )
        } else {
          this.toastr.clear();
          this.errormessage = '*An account does not exist with this Email , Try Again';
          this.showNotification('top', 'center' , this.errormessage);
          return;
        }
      }, 1000);  
  }
  SubmitResetPassword(){
    if(!this.ResetEmail || !this.OldPassword ||  !this.NewPassword || !this.ConfirmNewPassword){
      this.toastr.clear();
      this.errormessage = '*Please Fill Out All Fields';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    var  serchfind:boolean;
    serchfind = this.regexp.test(this.ResetEmail);
    if(serchfind != true){
      this.toastr.clear();
      this.errormessage = '*Email Must be in Correct Format';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    if(this.NewPassword.length < 8 || this.NewPassword.length > 16){
      this.toastr.clear();
      this.errormessage = '*New Password Length Must be between 8 and 16 characters';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    if(this.NewPassword != this.ConfirmNewPassword){
      this.toastr.clear();
      this.errormessage = '*New Password and Confirm New Password Must Match';
      this.showNotification('top', 'center' , this.errormessage);
      return;
    }
    this.http.get('https://localhost:44380/api/CheckUserEmail/'+ this.ResetEmail).subscribe(
      (response2 : test[]) => {
        this.CheckEmail = response2;
      }, (error) => {console.log('error message ' + error)} 
    )
    setTimeout(()=>{
      if(this.CheckEmail[0].response == 'Found'){
          this.toastr.clear();
          this.http.get('https://localhost:44380/api/CheckEmailPasswordExist/'+ this.ResetEmail + '/' + this.OldPassword).subscribe(
            (response2 : test[]) => {
              this.CheckPassword = response2;
            }, (error) => {console.log('error message ' + error)} 
          )
          setTimeout(()=> {
            if(this.CheckPassword[0].response == 'Found'){
              var result: UpdaetPasswords = [
                {   Email : this.ResetEmail.toString() , Password : this.NewPassword.toString()  }
                ];
                const httpOptions = {
                  headers: new HttpHeaders({'Content-Type': 'application/json'})
                }    
                
               this.http.post('https://localhost:44380/api/UpdateResetPassword' , result[0] , httpOptions).subscribe(data => {
                   console.log(data)
                   this.isPasswordResetGood = true;
                  }, error => {
                 console.log(error)
               });
            } else {
              this.toastr.clear();
              this.errormessage = '*Old Password Incorrect , Try Again!';
              this.showNotification('top', 'center' , this.errormessage);
              return;
            }
          }, 1000);
          
      } else {
        this.toastr.clear();
        this.errormessage = '*No Account Associated with Provided Email was Found, Try Again!';
        this.showNotification('top', 'center' , this.errormessage);
        return;
      }} , 1000);
  }
  ReturnToStart(){
    this.isMainLogin = true;
    this.isForgotPassword = false;
    this.isResetPassword = false;
  }
  Login(){
    if(!this.Email || !this.Password){
      this.toastr.clear();
      this.errormessage = '*Please Fill Email & Password';
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
                        console.log("test");
                        this.http.get('https://localhost:44380/api/GetResourceManagerInfo/' + this.Email + '/' + this.Password) .subscribe(
                          (response3 : rmanager[]) =>{
                            this.rmlogin = response3;
                            if(this.rmlogin.length === 0){
                              this.toastr.clear();
                              this.errormessage = 'Email or Password Incorrect , Try again!';
                              this.showNotification('top', 'center' , this.errormessage);
                              setTimeout(()=> this.toastr.clear(), 3000);
                              return;
                            } else {
                              this.RFirstName = this.rmlogin[0].firstName;
                              this.RLastName = this.rmlogin[0].lastName;
                              this.REmail2 = this.rmlogin[0].email;
                              this.RPassword2 = this.rmlogin[0].password;
                              this.ResourceManagerID = this.rmlogin[0].resourceManagerID;
                              this.RPhoneNumber = this.rmlogin[0].phoneNumber;
                              this.RRoleDesc = this.rmlogin[0].roleDesc;
                              this.RPhoto = this.rmlogin[0].photo;
                              this.RSideBarColor = this.rmlogin[0].sideBarColor;
                              this.RDashboardColor = this.rmlogin[0].dashboardColor;
                              this.CnotD = 'resourcemanager';
                              this.router.navigate(['./rmorders'], {state: {type: this.CnotD, FirstName: this.RFirstName , LastName: this.RLastName, PhoneNumber : this.RPhoneNumber , Email : this.REmail2, Password : this.RPassword2 
                                ,ResourceManagerID : this.ResourceManagerID ,RoleDesc : this.RRoleDesc , Photo : this.RPhoto , SideBarColor : this.RSideBarColor , DashboardColor : this.RDashboardColor}});
                              }
                            } , (error) => {console.log('error message ' + error)} );
                            
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
                        this.DPhoto = this.developerlogin[0].photo;
                        this.DSideBarColor = this.developerlogin[0].sideBarColor;
                        this.DDashboardColor = this.developerlogin[0].dashboardColor;
                        this.CnotD = 'developer';
                        this.router.navigate(['./devorders'], 
                        {state: {type: this.CnotD, FirstName: this.DFirstName , LastName: this.DLastName, PhoneNumber : this.DPhoneNumber , Email : this.DEmail2, Password : this.DPassword2
                        , Description : this.DDescription , PLanguages : this.DPLanguages , Skills : this.DSkills, Education : this.DEducation , Certification : this.DCertificates,
                          Title : this.DTitle , DeveloperID : this.DeveloperID , RoleDesc : this.DRoleDesc , Photo : this.DPhoto , SideBarColor : this.DSideBarColor , DashboardColor : this.DDashboardColor }});
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
            this.CPhoto = this.loginresponse[0].photo;
            this.CSideBarColor = this.loginresponse[0].sideBarColor;
            this.CDashboardColor = this.loginresponse[0].dashboardColor;
            this.CnotD = 'customer';
            this.router.navigate(['./customerdashboard'], {state: {type: this.CnotD, FirstName: this.CFirstName , LastName: this.CLastName, PhoneNumber : this.CPhoneNumber , Email : this.CEmail2, Password : this.CPassword2 
              ,CustomerID : this.CustomerID ,RoleDesc : this.CRoleDesc , Photo : this.CPhoto , SideBarColor : this.CSideBarColor , DashboardColor : this.CDashboardColor}});
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
