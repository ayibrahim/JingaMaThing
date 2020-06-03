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
}
@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
  providers: [ Globals ] 
})
export class SignInComponent implements OnInit {
  constructor(public globals: Globals , private router : Router , private toastr: ToastrService , private http : HttpClient) { }
  Email: string; Password: string; errormessage: string; loginresponse: customer[];
  FirstName : string; LastName : string; Email2 : string; Password2: string; CustomerID : number; PhoneNumber : string; RoleDesc : string;
  regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
  ngOnInit() {

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
            this.toastr.clear();
            this.errormessage = '*Email or Password Incorrect. Try again!';
            this.showNotification('top', 'center' , this.errormessage);
            return;
          }else {
            this.FirstName = this.loginresponse[0].firstName;
            this.LastName = this.loginresponse[0].lastName;
            this.Email2 = this.loginresponse[0].email;
            this.Password2 = this.loginresponse[0].password;
            this.CustomerID = this.loginresponse[0].customerID;
            this.PhoneNumber = this.loginresponse[0].phoneNumber;
            this.RoleDesc = this.loginresponse[0].roleDesc;
            this.router.navigate(['./dashboard'], {state: { FirstName: this.FirstName , LastName: this.LastName, PhoneNumber : this.PhoneNumber , Email : this.Email2, Password : this.Password2 ,CustomerID : this.CustomerID ,RoleDesc : this.RoleDesc}});
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
