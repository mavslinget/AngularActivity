import { Component, OnInit, ViewChild } from '@angular/core';
import { Show } from '../../domain/show';
import { ShowService } from '../../services/show.service';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { DataTable } from 'primeng/primeng';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css'],
  providers: [ShowService]
})
export class ShowComponent implements OnInit {
  showList: Show[];
  selectShow: Show;
  showForm: FormGroup;
  isAddShow: boolean;
  indexOfShow: number = 0;
  isDeleteShow: boolean;
  totalRecords: number = 0;
  searchShowName: string = "";

  constructor(private showService: ShowService, private fb: FormBuilder) { }

  @ViewChild('dt') public dataTable: DataTable;
  ngOnInit() {
    this.showForm = this.fb.group({
      'title': new FormControl('', Validators.required),
      'alternativeTitle': new FormControl(''),
      'genre': new FormControl('', Validators.required),
      'numberOfEpisode': new FormControl('', Validators.required),
      'isComplete': new FormControl('', Validators.required),
      'description': new FormControl('', Validators.required),
      'country': new FormControl('', Validators.required),
      'yearStarted': new FormControl(''),
      'season': new FormControl('', Validators.required)
    });


  }

  loadAllShows() {
    this.showService.getShow().then(result => {
      this.showList = result;
    })
  }

  paginate($event) {
    //event.first = Index of the first record
    //event.rows = Number of rows to display in new page
    //event.page = Index of the new page
    //event.pageCount = Total number of pages

    this.showService.getShowWithPagination($event.first, $event.rows, this.searchShowName)
      .then(result => {
        this.totalRecords = result.totalRecords;
        this.showList = result.results;

      })
  }

  searchShow() {
    if(this.searchShowName.length != 1) {
      this.resetTable();
    }
  }

  resetTable() {
    this.dataTable.reset();
    
  }

  addShow() {
    this.showForm.enable();
    this.isDeleteShow = false;
    this.isAddShow = true;
    this.selectShow = {} as Show;
    
  }

 
  editShow(Show) {
    this.showForm.enable();
    this.isDeleteShow = false;
    this.indexOfShow = this.showList.indexOf(Show);
    this.isAddShow = false;
    this.selectShow = Show;
    this.selectShow = Object.assign({}, this.selectShow);    
  }

  deleteShow(Show) {
    this.showForm.disable();
    this.isDeleteShow = true;
    this.indexOfShow = this.showList.indexOf(Show);
    this.selectShow = Show;
    this.selectShow = Object.assign({}, this.selectShow);  
  }

  okDelete() {
    let tmpShowList = [...this.showList];
    this.showService.deleteShow(this.selectShow.showID)
        .then(() => {
          tmpShowList.splice(this.indexOfShow, 1);
          this.showList = tmpShowList;
          this.selectShow = null;
        });
  }


  saveShow() {
    let tmpShowList = [...this.showList];
    if (this.isAddShow == true) {
      this.showService.addShow(this.selectShow).then(result => {
        tmpShowList.push(result);
        this.showList = tmpShowList;
        this.selectShow = null; 
      });
    }
    else {
      this.showService.editShow(this.selectShow.showID, this.selectShow).then(result => {
        tmpShowList[this.indexOfShow] = result;
        this.showList = tmpShowList;
        this.selectShow = null; 
      });
    }
    
  }

  cancelShow() {
    this.selectShow = null;
  }
}
