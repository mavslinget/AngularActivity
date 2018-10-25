import { Component, OnInit, ViewChild } from '@angular/core';
import { Name } from '../../domain/name';
import { NameService } from '../../services/name.service';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { DataTable } from 'primeng/primeng';

@Component({
  selector: 'app-name',
  templateUrl: './name.component.html',
  styleUrls: ['./name.component.css'],
  providers: [NameService]
})
export class NameComponent implements OnInit {
  nameList: Name[];
  selectName: Name;
  nameFormGroup: FormGroup;
  isAddName: boolean;
  indexOfName: number = 0;
  isDeleteName: boolean;
  totalRecords: number = 0;
  searchNameName: string = "";

  constructor(private nameService: NameService, private fb: FormBuilder) { }

  @ViewChild('dt') public dataTable: DataTable;
  ngOnInit() {
    this.nameFormGroup = this.fb.group({
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
    });


  }

  paginate($event) {
    //event.first = Index of the first record
    //event.rows = Number of rows to display in new page
    //event.page = Index of the new page
    //event.pageCount = Total number of pages

    this.nameService.getNameWithPagination($event.first, $event.rows, this.searchNameName)
      .then(result => {
        this.totalRecords = result.totalRecords;
        this.nameList = result.results;

      })
  }

  searchName() {
    if(this.searchNameName.length != 1) {
      this.resetTable();
    }
  }

  resetTable() {
    this.dataTable.reset();
  }

  addName() {
    this.nameFormGroup.enable();
    this.isDeleteName = false;
    this.isAddName = true;
    this.selectName = {} as Name;
    
  }

 
  editName(Name) {
    this.nameFormGroup.enable();
    this.isDeleteName = false;
    this.indexOfName = this.nameList.indexOf(Name);
    this.isAddName = false;
    this.selectName = Name;
    this.selectName = Object.assign({}, this.selectName);    
  }

  deleteName(Name) {
    this.nameFormGroup.disable();
    this.isDeleteName = true;
    this.indexOfName = this.nameList.indexOf(Name);
    this.selectName = Name;
    this.selectName = Object.assign({}, this.selectName);  
  }

  okDelete() {
    let tmpNameList = [...this.nameList];
    this.nameService.deleteName(this.selectName.nameID)
        .then(() => {
          tmpNameList.splice(this.indexOfName, 1);
          this.nameList = tmpNameList;
          this.selectName = null;
          this.dataTable.reset();
        });
  }


  saveName() {
    let tmpNameList = [...this.nameList];
    if (this.isAddName == true) {
      this.nameService.addName(this.selectName).then(result => {
        tmpNameList.push(result);
        this.nameList = tmpNameList;
        this.selectName = null; 
        this.dataTable.reset();
      });
    }
    else {
      this.nameService.editName(this.selectName.nameID, this.selectName).then(result => {
        tmpNameList[this.indexOfName] = result;
        this.nameList = tmpNameList;
        this.selectName = null; 
        this.dataTable.reset();
      });
    }
    
  }

  cancelName() {
    this.selectName = null;
  }
}
