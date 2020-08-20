import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import {formatDate} from '@angular/common';
import { MenuItem } from 'primeng';
export interface rmanager{ 
  resourceManagerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; roleDesc : string; photo : string;
}
export interface TaskTable {
  developerTaskID : number; orderNumber : number; title : string; description : string; notes : string; status : string;
}
export interface UpdateOrder {  
  OrderNumber : string; NewPrice : string; DateBy : string; Requirements : string;
}
export interface headers{}
interface UpdateRMOrder extends Array<UpdateOrder>{}
@Component({
  selector: 'app-rmorders',
  templateUrl: './rmorders.component.html',
  styleUrls: ['./rmorders.component.css']
})
export class RmordersComponent implements OnInit {
  nodevorders : boolean = true; errormessage : String;  newdata : headers[]; i : any;
  retrievedID : string; retrievedRole : string; rmanagerId : any; isrmanager : boolean = false; rmresponse : rmanager[];
  RFirstName : string; RLastName : string; REmail2 : string; REmail : string; RPassword: string; ResourceManagerID : number; RPhoneNumber : string; RRoleDesc : string; RPhoto : any;
  DORHeaders : any[]; DORData: any[]; selecteddata1 : any; neworderdialog : boolean = false; OrderIDSelected : any; NPrice : any; NRequirements : any; NDateBy : any;
  notasks : boolean = true; TasksHeaders : any[]; TasksData : any[];  selecteddata2 : any; OrderSelectedLoadTask : boolean = false; currentdate : any;
  items: MenuItem[]; isOpenOrder: boolean = true; MenuLabelChosen : any; isOrderHistory : boolean = false; isPendingOrder : boolean = false;
  CustApprovPendingHeader : any[];CustApprovPendingData : any[]; selecteddata4 : any; custpendingdata : boolean = true;
  nopendingdata1 : boolean = true; CustomerPendingHeader : any[]; CustomerPendingResponse : any[]; selecteddata5 : any;
  noorderhistory : boolean = true; DevOrderHistoryHeaders : any[]; DevOrderHistory: any[]; devhistoryselected : any;
  constructor(private route: ActivatedRoute , private router : Router ,private http: HttpClient , private toastr: ToastrService) { }

  ngOnInit() {
    this.route.queryParams.subscribe((params=>{
      this.retrievedID = params.data;
      this.retrievedRole = params.data2;
      if(this.retrievedRole == 'ResourceManager'){
        this.rmanagerId = this.retrievedID;
      } 
      else if(this.retrievedRole == undefined){
        if(history.state.type == 'resourcemanager'){
          this.rmanagerId = history.state.ResourceManagerID;
        } 
      }
    }))
    if(this.rmanagerId != undefined){
      this.isrmanager = true;
      this.http.get('https://localhost:44380/api/GetResourceManagerInfoByID/' + this.rmanagerId)
      .subscribe(
          (response : rmanager[] ) => {
           this.rmresponse = response;
           this.RFirstName = this.rmresponse[0].firstName;
            this.RLastName = this.rmresponse[0].lastName;
            this.REmail = this.rmresponse[0].email;
            this.REmail2 = this.rmresponse[0].email;
            this.RPassword = this.rmresponse[0].password;
            this.ResourceManagerID = this.rmresponse[0].resourceManagerID;
            this.RPhoneNumber = this.rmresponse[0].phoneNumber;
            this.RRoleDesc = this.rmresponse[0].roleDesc;
            this.RPhoto = this.rmresponse[0].photo;
            this.GetRMDevOpenOrders();
          }, (error) => {console.log('error message ' + error)}
          )
    } else {
      this.router.navigate(['./access-denied']);
    }
    this.items = [
      {label: 'Open Orders', icon: 'pi pi-fw pi-th-large' , styleClass: "testingstyle"},
      {label: 'Pending Orders', icon: 'pi pi-fw pi-eye'},
      {label: 'Order History', icon: 'pi pi-fw pi-search'}
  ];
    this.currentdate = formatDate(new Date(), 'yyyy-MM-dd', 'en_US');
  }
  GetDevPendingCustomerOrders(){
    this.http.get('https://localhost:44380/api/GetPendingCustomerResponseRM/' + this.ResourceManagerID).subscribe(
    (response : headers[]) => {
      this.CustApprovPendingData = response;
      if (this.CustApprovPendingData.length == 0){
        this.custpendingdata = true;
      } else {
        this.custpendingdata = false;
      }
      this.CustApprovPendingHeader = [];
      for (this.i = 0; this.i < this.CustApprovPendingData.length; this.i++){
        for (var key in this.CustApprovPendingData[this.i]){
          if(this.CustApprovPendingHeader.indexOf(key) === -1){
            if(key == 'requirements' || key == 'customerPendingID'){

            }else {
              this.CustApprovPendingHeader.push(key);
            }
            
          }
        }
      }   
    }, (error) => {this.custpendingdata = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Pending Orders Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  GetCPendingOrders(){
    this.http.get('https://localhost:44380/api/GetPendingDevResponseRM/' + this.ResourceManagerID).subscribe(
    (response : headers[]) => {
      this.CustomerPendingResponse = response;
      if (this.CustomerPendingResponse.length == 0){
        this.nopendingdata1 = true;
      } else {
        this.nopendingdata1 = false;
      }
      this.CustomerPendingHeader = [];
      for (this.i = 0; this.i < this.CustomerPendingResponse.length; this.i++){
        for (var key in this.CustomerPendingResponse[this.i]){
          if(this.CustomerPendingHeader.indexOf(key) === -1){
            if(key == 'requirements' || key == 'developerPendingID'){

            }else {
              this.CustomerPendingHeader.push(key);
            }
            
          }
        }
      }   
    }, (error) => {this.nopendingdata1 = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Pending Orders Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  GetCustomerHistoryOrders()
  {
    this.http.get('https://localhost:44380/api/GetDevOrderHistoryRM/' + this.ResourceManagerID).subscribe(
    (response : headers[]) => {
      this.DevOrderHistory = response;
      console.log(this.DevOrderHistory);
      if(this.DevOrderHistory.length == 0){
        this.noorderhistory = true;
        this.toastr.clear();
        this.errormessage = 'No Previous Orders Found.';
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.noorderhistory = false;
      }
      this.DevOrderHistoryHeaders = [];
      for (this.i = 0; this.i < this.DevOrderHistory.length; this.i++){
        for (var key in this.DevOrderHistory[this.i]){
          if(this.DevOrderHistoryHeaders.indexOf(key) === -1){
            if(key == 'requirements'){

            }else {
              this.DevOrderHistoryHeaders.push(key);
            }
          }
        }
      }   
    }, (error) => {this.noorderhistory = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Previous Orders Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  menuswitch(event){
    this.MenuLabelChosen = event.toElement.parentNode.innerText;
    this.toastr.clear();
    if(this.MenuLabelChosen == "Open Orders"){
      this.isOrderHistory = false;
      this.isPendingOrder = false;
      this.isOpenOrder = true;
      this.GetRMDevOpenOrders();
    }
    if(this.MenuLabelChosen == "Pending Orders"){
      this.isOrderHistory = false;
      this.isOpenOrder = false;
      this.isPendingOrder = true;
      this.GetDevPendingCustomerOrders();
      this.GetCPendingOrders();
    }
    if(this.MenuLabelChosen == "Order History"){
      this.isPendingOrder = false;
      this.isOpenOrder = false;
      this.isOrderHistory = true;
      this.GetCustomerHistoryOrders();
    }
  }
  OnOrderSelect(event){
    console.log(event.data);
  }
  HideEditDialog(){ this.neworderdialog = false;}
  EditOrder(item : any){
    this.neworderdialog = true;
    this.OrderIDSelected = item.orderNumber;
    this.NPrice = undefined;
    this.NDateBy = undefined;
    this.NRequirements = undefined;
  }
  onDate(){
    this.NDateBy = this.convert(this.NDateBy);
  }
 convert(str){
   var date = new Date(str),
   mnth = ("0" + (date.getMonth() + 1)).slice(-2),
   day = ("0" + date.getDate()).slice(-2);
   return [date.getFullYear(),mnth , day].join("-");
 }
  GetRMDevOpenOrders()
  {
    this.http.get('https://localhost:44380/api/GetDevRMOpenOrders/' + this.ResourceManagerID).subscribe(
    (response : headers[]) => {
      this.DORData = response;
      console.log(this.DORData);
      if(this.DORData.length == 0){
        this.nodevorders = true;
        this.toastr.clear();
        this.errormessage = 'No Open Orders Found.';
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.nodevorders = false;
      }
      this.DORHeaders = [];
      for (this.i = 0; this.i < this.DORData.length; this.i++){
        for (var key in this.DORData[this.i]){
          if(this.DORHeaders.indexOf(key) === -1){
            if(key == 'customerID' || key == 'requirements' || key == 'developerID'){

            }else {
              this.DORHeaders.push(key);
            }
          }
        }
      }   
    }, (error) => {this.nodevorders = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Open Orders Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  UpdateOrder()
  {
    if( !this.NPrice || !this.NRequirements  || !this.NDateBy){
      this.toastr.clear();
      this.errormessage = '*Please Fill out all fields';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=>{   this.toastr.clear(); }, 4000);
      return;
    }
    let date2 = formatDate(this.NDateBy , 'yyyy-MM-dd' , 'en_US');
    if(this.currentdate >= date2){
      this.toastr.clear();
      this.errormessage = '*Date Requested must be greater than ' + this.currentdate;
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=>{ this.toastr.clear();}, 4000);
      return;
    } 
    var result2 : UpdateRMOrder = [
      {  OrderNumber : this.OrderIDSelected.toString() , NewPrice : this.NPrice.toString() , DateBy : this.NDateBy.toString() , Requirements : this.NRequirements.toString() }
      ];
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }
    this.http.post('https://localhost:44380/api/UpdateRMOpenOrder' , result2[0] , httpOptions).subscribe(
      (response : headers[]) => {
        this.newdata = response;
        console.log(this.newdata);
        this.toastr.clear();
        this.errormessage = 'Order Updated Successfully';
        this.showNotification('top', 'center' , this.errormessage);
      }, (error) => {this.toastr.clear();
        this.errormessage = 'Error Happened When Updating Order , Refresh and Try Again!';
        this.showNotification('top', 'center' , this.errormessage);
        console.log('error message ' + error)}
      )
    this.neworderdialog = false; this.NPrice = undefined; this.NDateBy = undefined; this.NRequirements = undefined; this.OrderIDSelected = undefined;
    setTimeout(()=> this.GetRMDevOpenOrders(), 2000) ;
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  GetOrderTasks(event)
  {
    this.OrderSelectedLoadTask = true;
    this.http.get('https://localhost:44380/api/GetOrderTasks/' + event.data.orderNumber).subscribe(
    (response : TaskTable[]) => {
      this.TasksData = response;
      console.log(this.TasksData);
      if(this.TasksData.length == 0){
        this.notasks = true;
        this.toastr.clear();
        this.errormessage = 'No Tasks Found.';
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.notasks = false;
      }
      this.TasksHeaders = [];
      for (this.i = 0; this.i < this.TasksData.length; this.i++){
        for (var key in this.TasksData[this.i]){
          if(this.TasksHeaders.indexOf(key) === -1){
            if(key == 'developerTaskID' || key =='notes'){

            }else {
              this.TasksHeaders.push(key);
            }
          }
        }
      }   
    }, (error) => {this.notasks = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Tasks for Order Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
    setTimeout(()=> this.toastr.clear() , 4000);
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
