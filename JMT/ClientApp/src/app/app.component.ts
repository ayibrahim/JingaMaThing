import { Component, OnInit, ViewChild } from "@angular/core";
import { PhotoServiceService } from './Shared/photo-service.service';
import { Galleria } from 'primeng';

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit {
  title = "Jinga-Ma-Thing";
  
  constructor() { }
  
  ngOnInit(){
  }
}
