import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Qualification } from '../../domain/qualification';
import { QualificationService } from '../../services/qualification.service';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { DataTable } from 'primeng/primeng';
import { DatePipe } from '@angular/common';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog} from '@angular/material';


@Component({
  selector: 'app-qualification',
  templateUrl: './qualification.component.html',
  styleUrls: ['./qualification.component.css'],
  providers: [QualificationService, DatePipe]
})
export class QualificationComponent implements OnInit {
  dataSource;
  displayedColumns: string[] = ['choose', 'qualificationID', 'description', 'price',
    'isActive', 'dateCreated'];
  qualificationList: Qualification[];
  selectQualification: Qualification;
  qualificationFormGroup: FormGroup;
  isAddQualification: boolean;
  indexOfQualification: number = 0;
  isDeleteQualification: boolean;
  totalRecords: number = 0;
  searchQualificationName: string = "";
  isActives: string[] = ['True', 'False'];
  dateCreated: Date;
  minDate = new Date(Date.now());
  getToday: string;
  rows:number = 5;

  constructor(private qualificationService: QualificationService, private fb: FormBuilder,
    private datePipe: DatePipe, private dialog: MatDialog) {
      
     }

  @ViewChild('dt') public dataTable: DataTable;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  
  ngOnInit() {
    this.qualificationFormGroup = this.fb.group({
      description: [''],
      price: ['', Validators.required],
      isActive: ['', Validators.required],
      dateCreated: ['', Validators.required],
      
    });

    this.loadAllQualifications();
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  loadAllQualifications() {
    this.qualificationService.getQualification().then(qualifications => {
      this.qualificationList = qualifications;
 
  
      for (let i = 0; i < this.qualificationList.length; i++) {
        this.qualificationList[i].dateCreated =
          this.datePipe.transform(this.qualificationList[i].dateCreated, 'yyyy-MM-dd');  
      }
      this.dataSource = new MatTableDataSource<Qualification>(this.qualificationList);
      this.dataSource.paginator = this.paginator;
    });
    
  }


  

  paginate($event) {
    this.qualificationService.getQualificationWithPagination($event.first, $event.rows, this.searchQualificationName)
      .then(result => {
        this.totalRecords = result.totalRecords;
        this.qualificationList = result.results;
        this.dataSource = new MatTableDataSource<Qualification>(this.qualificationList);
        this.dataSource.paginator = this.paginator;

        for (let i = 0; i < this.qualificationList.length; i++) {
          this.qualificationList[i].dateCreated=
            this.datePipe.transform(this.qualificationList[i].dateCreated, 'yyyy-MM-dd');
        }

      })
  }

  searchQualification() {
    if(this.searchQualificationName.length != 1) {
      this.resetTable();
    }
  }

  resetTable() {
    this.dataTable.reset();
  }

  
  

  addQualification() {
    this.qualificationFormGroup.enable();
    this.isDeleteQualification = false;
    this.isAddQualification = true;
    this.selectQualification = {} as Qualification;
    this.loadAllQualifications();
  }

 
  editQualification(Qualification) {
    this.qualificationFormGroup.enable();
    this.isDeleteQualification = false;
    this.indexOfQualification = this.qualificationList.indexOf(Qualification);
    this.isAddQualification = false;
    this.selectQualification = Qualification;
    this.selectQualification = Object.assign({}, this.selectQualification);   
    
    this.dateCreated = new Date(this.selectQualification.dateCreated);
    this.loadAllQualifications();
  }

  deleteQualification(Qualification) {
    
    this.qualificationFormGroup.disable();
    this.isDeleteQualification = true;
    this.indexOfQualification = this.qualificationList.indexOf(Qualification);
    this.selectQualification = Qualification;
    this.selectQualification = Object.assign({}, this.selectQualification);  
  }

  okDelete() {
    let tmpQualificationList = [...this.qualificationList];
    this.qualificationService.deleteQualification(this.selectQualification.qualificationID)
        .then(() => {
          tmpQualificationList.splice(this.indexOfQualification, 1);
          this.qualificationList = tmpQualificationList;
          this.selectQualification = null;
          this.loadAllQualifications();
        });
  }


  saveQualification() {
    let tmpQualificationList = [...this.qualificationList];

    this.selectQualification.dateCreated =
    this.datePipe.transform(this.selectQualification.dateCreated, 'yyyy-MM-dd');
    if (this.isAddQualification == true) {
      this.qualificationService.addQualification(this.selectQualification).then(result => {
        result.dateCreated =
        this.datePipe.transform(this.selectQualification.dateCreated, 'yyyy-MM-dd');
        tmpQualificationList.push(result);
        this.qualificationList = tmpQualificationList;
        this.selectQualification = null; 
        this.loadAllQualifications();
      });
    }
    else {
      this.qualificationService.editQualification(this.selectQualification.qualificationID, this.selectQualification).then(result => {
        result.dateCreated =
        this.datePipe.transform(this.selectQualification.dateCreated, 'yyyy-MM-dd');
        tmpQualificationList[this.indexOfQualification] = result;
        this.qualificationList = tmpQualificationList;
        this.selectQualification = null; 
        this.loadAllQualifications();
      });
    }
    
  }

  cancelQualification() {
    this.selectQualification = null;
  }
}