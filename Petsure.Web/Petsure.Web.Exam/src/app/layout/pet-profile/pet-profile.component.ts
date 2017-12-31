import { Component, OnInit, NgModule } from '@angular/core';
import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';

import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import { Subject } from 'rxjs/Subject';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { FileDropModule, UploadFile, UploadEvent } from 'ngx-file-drop';

@Component({
  selector: 'app-pet-profile',
  templateUrl: './pet-profile.component.html',
  styleUrls: ['./pet-profile.component.css'],
})

@Injectable()
export class PetProfileComponent implements OnInit {
 
    private headers: Headers;
    public files: UploadFile[] = [];
    petOptions: any;
    selectedValue:string;
    modalTitle: string;
    modalMessage:string;

    constructor(private http: Http,
                private modalService: NgbModal) { 
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');}

    ngOnInit() {
        this.getAllPetProfile().subscribe(response =>{
            this.petOptions = JSON.parse(response.json() || '[]');
        });
    }

    getAllPetProfile(): Observable<Response> {
        
        const url ='http://localhost:50950/api/petprofile';

        return this.http.get(url, { headers: this.headers })
            .map((response: Response) => {
                return response;
            }).catch(this.handleError);
    }
    
    private handleError(error: any) {
        if (error instanceof Response) {
            let errMessage = '';
            try {
                errMessage = error.json().error;
            } catch (err) {
                if (error.status === 401) {
                    errMessage = error.text();
                } else {
                    errMessage = error.statusText;
                }
            }
            return Observable.throw(errMessage);
        }
        return Observable.throw(error || 'server error');
    }

    public dropped(event: UploadEvent) {
        this.files = event.files;
    }

    saveFiles(content){
        if(this.selectedValue === undefined){
            this.modalTitle = "Warning";
            this.modalMessage = "Please select pet";
            this.modalService.open(content);
        }
        else{
                if(this.files[0] === undefined){
                    this.modalTitle = "Warning";
                    this.modalMessage = "Please select files to upload";
                    this.modalService.open(content);
                }
                else{
                    this.modalTitle = "Files uploaded";
                    let uploadedFiles = "";
                    let index = 0;
                    this.files.forEach(element => {
                        if(index > 0){
                            if(index == this.files.length - 1){
                                uploadedFiles += " and " + element.relativePath;
                            }
                            else{
                                uploadedFiles += ", " + element.relativePath;
                            }
                        }
                        else{
                            uploadedFiles = element.relativePath;
                        }
                        index ++;
                    });
                    this.modalMessage ="Thank you for submitting " + uploadedFiles + " for " + this.selectedValue;
                    this.modalService.open(content);
                }
            }
    }

    onChange(selected){
        this.selectedValue = selected;
    }
}
