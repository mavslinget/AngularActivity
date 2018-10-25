import { Component, OnInit, ViewChild } from '@angular/core';
import { Actor } from '../../domain/actor';
import { ActorService } from '../../services/actor.service';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { DataTable } from 'primeng/primeng';

@Component({
  selector: 'app-actor',
  templateUrl: './actor.component.html',
  styleUrls: ['./actor.component.css'],
  providers: [ActorService]
})
export class ActorComponent implements OnInit {
  actorList: Actor[];
  selectActor: Actor;
  actorForm: FormGroup;
  isAddActor: boolean;
  indexOfActor: number = 0;
  isDeleteActor: boolean;
  totalRecords: number = 0;
  searchActorName: string = "";

  constructor(private actorService: ActorService, private fb: FormBuilder) { }

  @ViewChild('dt') public dataTable: DataTable;
  ngOnInit() {
    this.actorForm = this.fb.group({
      'firstName': new FormControl('', Validators.required),
      'lastName': new FormControl('', Validators.required),
      'age': new FormControl('', Validators.required),
      'gender': new FormControl('', Validators.required),
      'nationality': new FormControl('', Validators.required),
      'country': new FormControl('', Validators.required),
      'numberOfFilm': new FormControl('', Validators.required),
      'socialMediaAccount': new FormControl(''),
      'isActive': new FormControl('', Validators.required)
    });


  }

  loadAllActors() {
    this.actorService.getActor().then(result => {
      this.actorList = result;
    })
  }

  paginate($event) {
    //event.first = Index of the first record
    //event.rows = Number of rows to display in new page
    //event.page = Index of the new page
    //event.pageCount = Total number of pages

    this.actorService.getActorWithPagination($event.first, $event.rows, this.searchActorName)
      .then(result => {
        this.totalRecords = result.totalRecords;
        this.actorList = result.results;

      })
  }

  searchActor() {
    if(this.searchActorName.length != 1) {
      this.resetTable();
    }
  }

  resetTable() {
    this.dataTable.reset();
  }

  addActor() {
    this.actorForm.enable();
    this.isDeleteActor = false;
    this.isAddActor = true;
    this.selectActor = {} as Actor;
    
  }

 
  editActor(Actor) {
    this.actorForm.enable();
    this.isDeleteActor = false;
    this.indexOfActor = this.actorList.indexOf(Actor);
    this.isAddActor = false;
    this.selectActor = Actor;
    this.selectActor = Object.assign({}, this.selectActor);    
  }

  deleteActor(Actor) {
    this.actorForm.disable();
    this.isDeleteActor = true;
    this.indexOfActor = this.actorList.indexOf(Actor);
    this.selectActor = Actor;
    this.selectActor = Object.assign({}, this.selectActor);  
  }

  okDelete() {
    let tmpActorList = [...this.actorList];
    this.actorService.deleteActor(this.selectActor.actorID)
        .then(() => {
          tmpActorList.splice(this.indexOfActor, 1);
          this.actorList = tmpActorList;
          this.selectActor = null;
        });
  }


  saveActor() {
    let tmpActorList = [...this.actorList];
    if (this.isAddActor == true) {
      this.actorService.addActor(this.selectActor).then(result => {
        tmpActorList.push(result);
        this.actorList = tmpActorList;
        this.selectActor = null; 
      });
    }
    else {
      this.actorService.editActor(this.selectActor.actorID, this.selectActor).then(result => {
        tmpActorList[this.indexOfActor] = result;
        this.actorList = tmpActorList;
        this.selectActor = null; 
      });
    }
    
  }

  cancelActor() {
    this.selectActor = null;
  }
}
