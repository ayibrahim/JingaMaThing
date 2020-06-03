import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
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
  constructor(private router: Router , private http : HttpClient) { }

  ngOnInit(): void {
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
}
