import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SelectItem, GalleriaThumbnails } from 'primeng';
export interface headers{}
export interface customer{ 
  customerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; roleDesc : string; photo : string;
}
export interface Developer{
  developerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; description : string; pLanguages : string; skills : string; education : string; certification : string; title : string; roleDesc : string; photo : string;
}
export interface UpdateNote {
  DeveloperNoteID : string ; NoteContent : string;
}
interface UpdateDevNote extends Array<UpdateNote>{}
@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {

  retrievedID : string; retrievedRole : string;customerId : string;developerId : string; errormessage : String;  newdata : headers[];
  iscustomer : boolean  = false; isdeveloper : boolean = false;
  CFirstName : string; CLastName : string; CEmail : string;  CustomerID : number; CPhoneNumber : string;  CPassword: string; CRoleDesc : string; CPhoto : any; CEmail2: string;
  DFirstName : string; DLastName : string; DEmail : string; DPassword: string; DeveloperID : number; DPhoneNumber : string; DPhoto : any; DEmail2 : string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string;
  developerlogin : Developer[]; loginresponse : customer[]; nodevnotes : boolean = true;
  NTitle : string;
  NotesTypes: SelectItem[]; blocked: boolean = true;
  NType: any; DevNotes : any[];  SelectedDevNoteID : string; SelectedTitle: string; SelectedNoteView : string; SelectedNoteTitleView : string;
  NewTitle : string; NewViewType : any;
  SelectedNote :string; deletedialog : boolean = false; editdialog : boolean = false; disabled : boolean = true;
  nopublicnotes : boolean = true; PublicNotes : any[]; publicblocked : boolean = true; PublicSelectedNote : string; PublicSelectedTitle : string;
  constructor(private route: ActivatedRoute , private router : Router ,private http: HttpClient , private toastr: ToastrService) { }

  ngOnInit() 
  {
    this.route.queryParams.subscribe((params=>{
      this.retrievedID = params.data;
      this.retrievedRole = params.data2;
      if(this.retrievedRole == 'Customer'){
        this.customerId = this.retrievedID;
      }
      if(this.retrievedRole == 'Developer'){
        this.developerId = this.retrievedID;
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
          }, (error) => {console.log('error message ' + error)}
          )
    }
    if(this.developerId != undefined){
      this.isdeveloper = true;
      this.http.get('https://localhost:44380/api/getDeveloperInfoByID/' + this.developerId)
            .subscribe(
                    (response2 : Developer[] ) => { 
                      this.developerlogin = response2;
                        this.DFirstName = this.developerlogin[0].firstName;
                        this.DLastName = this.developerlogin[0].lastName;
                        this.DEmail = this.developerlogin[0].email;
                        this.DEmail2 = this.developerlogin[0].email;
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
                        this.GetDeveloperNotes();
                        this.GetPublicNotes();
                        this.SelectedNote = '<div><h1>Hello ' + this.DFirstName + ' ' + this.DLastName + '!</h1></div><div><h2>Editor Disabled - Select Note To Start Editing.</h2></div><div><br></div>';
                        this.SelectedTitle = 'none';
                        this.PublicSelectedTitle = 'none';
                        this.PublicSelectedNote = '<div><h1>Hello ' + this.DFirstName + ' ' + this.DLastName + '!</h1></div><div><h2>Editor Disabled - Select Note To View its Content.</h2></div><div><br></div>';
                      }, (error) => {console.log('error message ' + error)}
                    )
                          
    }
    this.NotesTypes = [
      {label:'Public', value: 'Public'},
      {label:'Private', value: 'Private'}
    ]
    
  }

  CreateNewNote(){
    if(!this.NTitle){
      this.toastr.clear();
      this.errormessage = '*Note title is required';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear() , 3000);
      return;
    }
    if(!this.NType){
      this.toastr.clear();
      this.errormessage = '*Note Display Type is required';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear() , 3000);
      return;
    }
    this.http.get('https://localhost:44380/api/CreateDevNote/' + this.DeveloperID + '/' + this.NTitle + '/' + this.NType).subscribe(
      (response : headers[]) => {
        this.newdata = response;
        console.log(this.newdata);
        this.toastr.clear();
        this.errormessage = 'Note Created Successfully';
        this.showNotification('top', 'center' , this.errormessage);
        setTimeout(()=> this.toastr.clear() , 3000);
      }, (error) => {this.toastr.clear();
        this.errormessage = 'Error Happened When Creating Note , Refresh and Try Again!';
        this.showNotification('top', 'center' , this.errormessage);
        setTimeout(()=> this.toastr.clear() , 3000);
        console.log('error message ' + error)}
      )
    this.NTitle = undefined; this.NType = undefined;
    setTimeout(()=> this.GetDeveloperNotes() , 2000);
  }
  GetDeveloperNotes()
  {
    this.http.get('https://localhost:44380/api/GetDeveloperNotes/' + this.DeveloperID).subscribe(
      (response : headers[]) => {
        this.DevNotes = response;
        if (this.DevNotes.length == 0){
          this.nodevnotes = true;
        } else {
          this.nodevnotes = false;
        }
      }, (error) => {this.nodevnotes = true;this.toastr.clear();
        this.errormessage = 'Error Happened When Loading Dev Notes Try Again or Contact Support';
        this.showNotification('top', 'center' , this.errormessage);
        console.log('error message ' + error)}
      )
  }
  GetPublicNotes()
  {
    this.http.get('https://localhost:44380/api/GetPublicNotesDev/' + this.DeveloperID).subscribe(
      (response : headers[]) => {
        this.PublicNotes = response;
        if (this.PublicNotes.length == 0){
          this.nopublicnotes = true;
        } else {
          this.nopublicnotes = false;
        }
      }, (error) => {this.nopublicnotes = true;this.toastr.clear();
        this.errormessage = 'Error Happened When Loading Public Notes Try Again or Contact Support';
        this.showNotification('top', 'center' , this.errormessage);
        console.log('error message ' + error)}
      )
  }
  PublicNoteTitleClick(event)
  {
    this.PublicSelectedNote = event.value[0].noteContent;
    this.PublicSelectedTitle = event.value[0].title;
  }
  NoteTitleClick(event)
  {
    this.SelectedDevNoteID = event.value[0].developerNoteID;
    this.SelectedNote = event.value[0].noteContent;
    this.SelectedTitle = event.value[0].title;
    this.SelectedNoteView = event.value[0].viewType;
    this.SelectedNoteTitleView = this.SelectedTitle + ' - ' + this.SelectedNoteView;
    this.blocked = false;
  }
  EditDialogShow(){this.deletedialog = false; this.editdialog = true; this.NewTitle = undefined ; this.NewViewType = undefined; }
  CloseEditDialog(){this.editdialog = false;}
  DeleteDialogShow(){ this.deletedialog = true; this.editdialog = false; }
  CloseDeleteDialog(){ this.deletedialog = false;}
  DeleteNote()
  {
    this.http.get('https://localhost:44380/api/DeleteDevNote/' + this.SelectedDevNoteID) .subscribe(
      (response2 : headers[]) => {
        this.newdata = response2;
        this.toastr.clear();
        this.errormessage = 'Note Deleted Succesfully';
       this.showNotification('top', 'center' , this.errormessage);
      }, (error) => {this.toastr.clear();
       this.errormessage = 'Error Happened When Deleting Note , Refresh and Try Again!';
       this.showNotification('top', 'center' , this.errormessage);
       console.log('error message ' + error)}
     )
    this.deletedialog = false;
    this.blocked = true;
    this.SelectedDevNoteID = undefined;
    this.SelectedNote = undefined;
    this.SelectedNoteView = undefined;
    this.SelectedNoteTitleView = undefined;
    this.SelectedTitle = 'none';
    this.SelectedNote = '<div><h1>Hello ' + this.DFirstName + ' ' + this.DLastName + '!</h1></div><div><h2>Editor Disabled - Select Note To Start Editing.</h2></div><div><br></div>';
    setTimeout(()=> this.GetDeveloperNotes() , 2000);
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  EditNote()
  {
    if(!this.NewTitle){
      this.toastr.clear();
      this.errormessage = '*New Title is required';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear() , 3000);
      return;
    }
    if(!this.NewViewType){
      this.toastr.clear();
      this.errormessage = '*New Display Type is required';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear() , 3000);
      return;
    }
    this.http.get('https://localhost:44380/api/EditDevNoteTitleViewType/' + this.SelectedDevNoteID + '/' + this.NewTitle + '/' + this.NewViewType) .subscribe(
      (response2 : headers[]) => {
        this.newdata = response2;
        this.toastr.clear();
        this.errormessage = 'Note Updated Succesfully';
       this.showNotification('top', 'center' , this.errormessage);
      }, (error) => {this.toastr.clear();
       this.errormessage = 'Error Happened When Updating Note , Refresh and Try Again!';
       this.showNotification('top', 'center' , this.errormessage);
       console.log('error message ' + error)}
     )
     this.SelectedTitle = this.NewTitle;
     this.SelectedNoteView = this.NewViewType;
     this.editdialog = false;
     setTimeout(()=> this.GetDeveloperNotes() , 2000);
     setTimeout(()=> this.toastr.clear() , 4000);
  }
  UpdateNote()
  {
    console.log(this.SelectedNote);
    var result2 : UpdateDevNote = [
      {  DeveloperNoteID : this.SelectedDevNoteID.toString() , NoteContent : this.SelectedNote.toString() }
      ];
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }    
     this.http.post('https://localhost:44380/api/UpdateDeveloperNote' , result2[0] , httpOptions).subscribe(data => {
      this.toastr.clear();
      this.errormessage = 'Note Updated Succesfully';
      this.showNotification('top', 'center' , this.errormessage);
        }, error => {
          this.toastr.clear();
          this.errormessage = 'Error Happened When Updating Note , Refresh and Try Again!';
          this.showNotification('top', 'center' , this.errormessage);
          setTimeout(()=>  this.toastr.clear() , 2000);
          console.log('error message ' + error)
     });
    setTimeout(()=> this.GetDeveloperNotes() , 2000);
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