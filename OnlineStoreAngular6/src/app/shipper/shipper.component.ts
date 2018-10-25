import { Component, OnInit, ViewChild } from '@angular/core';
import { Shipper } from '../../domain/shipper';
import { ShipperService } from '../../services/shipper.service';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { DataTable } from 'primeng/primeng';

@Component({
  selector: 'app-shipper',
  templateUrl: './shipper.component.html',
  styleUrls: ['./shipper.component.css'],
  providers: [ShipperService]
})
export class ShipperComponent implements OnInit {
  shipperList: Shipper[];
  selectShipper: Shipper;
  shipperForm: FormGroup;
  isAddShipper: boolean;
  indexOfShipper: number = 0;
  isDeleteShipper: boolean;
  totalRecords: number = 0;
  searchShipperName: string = "";

  constructor(private shipperService: ShipperService, private fb: FormBuilder) { }

  @ViewChild('dt') public dataTable: DataTable;  
  ngOnInit() {
    this.shipperForm = this.fb.group({
      'companyName': new FormControl('', Validators.required),
      'phone': new FormControl('', Validators.required)
    });

    this.loadAllShippers();
  }

  loadAllShippers() {
    this.shipperService.getShipper().then(result => {
      this.shipperList = result;
    })
  }

  paginate($event) {
    //event.first = Index of the first record
    //event.rows = Number of rows to display in new page
    //event.page = Index of the new page
    //event.pageCount = Total number of pages

    this.shipperService.getShipperWithPagination($event.first, $event.rows, this.searchShipperName)
      .then(result => {
        this.totalRecords = result.totalRecords;
        this.shipperList = result.results;

      })
  }

  searchShipper() {
    if(this.searchShipperName.length != 1) {
      this.resetTable();
    }
  }

  resetTable() {
    this.dataTable.reset();
  }

  addShipper() {
    this.shipperForm.enable();
    this.isDeleteShipper = false;
    this.isAddShipper = true;
    this.selectShipper = {} as Shipper;
  }

 
  editShipper(Shipper) {
    this.shipperForm.enable();
    this.isDeleteShipper = false;
    this.indexOfShipper = this.shipperList.indexOf(Shipper);
    this.isAddShipper = false;
    this.selectShipper = Shipper;
    this.selectShipper= Object.assign({}, this.selectShipper);    
  }

  deleteShipper(Shipper) {
    this.shipperForm.disable();
    this.isDeleteShipper= true;
    this.indexOfShipper= this.shipperList.indexOf(Shipper);
    this.selectShipper = Shipper;
    this.selectShipper = Object.assign({}, this.selectShipper);  
  }

  okDelete() {
    let tmpShipperList = [...this.shipperList];
    this.shipperService.deleteShipper(this.selectShipper.shipperID)
        .then(() => {
          tmpShipperList.splice(this.indexOfShipper, 1);
          this.shipperList = tmpShipperList;
          this.selectShipper = null;
        });
  }


  saveShipper() {
    let tmpShipperList = [...this.shipperList];
    if (this.isAddShipper == true) {
      this.shipperService.addShipper(this.selectShipper).then(result => {
        tmpShipperList.push(result);
        this.shipperList = tmpShipperList;
        this.selectShipper = null; 
      });
    }
    else {
      this.shipperService.editShipper(this.selectShipper.shipperID, this.selectShipper).then(result => {
        tmpShipperList[this.indexOfShipper] = result;
        this.shipperList = tmpShipperList;
        this.selectShipper = null; 
      });
    }
    
  }

  cancelShipper() {
    this.selectShipper = null;
  }
}
