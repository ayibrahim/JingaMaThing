import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
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
  selectedPhoto = null;
  public progress: number;
  public message: string;
  isImageLoading : boolean;
  imageToShow: any;
  constructor(private router: Router , private http : HttpClient) { }

  ngOnInit() {
    //this.onSignIn();
  }
  onSignIn(){
    this.isnotLoggedIn = false;
    this.SingingUp = false;
    this.LoggingIn = true;
    
  }
  onSignUp(){
    this.isnotLoggedIn = false;
    this.LoggingIn = false;
    this.SingingUp = true;
    
  }
  testing(files){
    this.selectedPhoto = files;
  }

}
