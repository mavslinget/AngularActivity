import { Component, OnInit, ViewChild } from '@angular/core';
import { Supplier } from '../../domain/supplier';
import { SupplierService } from '../../services/supplier.service';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { DataTable } from 'primeng/primeng';


@Component({
  selector: 'app-Supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css'],
  providers: [SupplierService]
})
export class SupplierComponent implements OnInit {
  supplierList: Supplier[];
  selectSupplier: Supplier;
  supplierForm: FormGroup;
  isAddSupplier: boolean;
  indexOfSupplier: number = 0;
  isDeleteSupplier: boolean;
  totalRecords: number = 0;
  searchSupplierName: string = "";
  

  constructor(private supplierService: SupplierService, private fb: FormBuilder) { }

  @ViewChild('dt') public dataTable: DataTable;
  ngOnInit() {
    this.supplierForm = this.fb.group({
      'companyName': new FormControl('', Validators.required),
      'contactTitle': new FormControl('', Validators.required),
      'address': new FormControl('', Validators.required),
      'city': new FormControl('', Validators.required),
      'region': new FormControl('', Validators.required),
      'postalCode': new FormControl('', Validators.required),
      'country': new FormControl('', Validators.required),
      'phone': new FormControl('', Validators.required),
      'fax': new FormControl('', Validators.required),
      'homePage': new FormControl('', Validators.required)
    });

    this.loadAllSuppliers();
  }

  loadAllSuppliers() {
    this.supplierService.getSupplier().then(result => {
      this.supplierList = result;
    })
  }

  paginate($event) {
    //event.first = Index of the first record
    //event.rows = Number of rows to display in new page
    //event.page = Index of the new page
    //event.pageCount = Total number of pages

    this.supplierService.getSupplierWithPagination($event.first, $event.rows, this.searchSupplierName)
      .then(result => {
        this.totalRecords = result.totalRecords;
        this.supplierList = result.results;

      })
  }

  searchSupplier() {
    if(this.searchSupplierName.length != 1) {
      this.resetTable();
    }
  }

  resetTable() {
    this.dataTable.reset();
  }


  addSupplier() {
    this.supplierForm.enable();
    this.isDeleteSupplier = false;
    this.isAddSupplier = true;
    this.selectSupplier = {} as Supplier;
  }

 
  editSupplier(Supplier) {
    this.supplierForm.enable();
    this.isDeleteSupplier = false;
    this.indexOfSupplier = this.supplierList.indexOf(Supplier);
    this.isAddSupplier = false;
    this.selectSupplier = Supplier;
    this.selectSupplier= Object.assign({}, this.selectSupplier);    
  }

  deleteSupplier(Supplier) {
    this.supplierForm.disable();
    this.isDeleteSupplier= true;
    this.indexOfSupplier= this.supplierList.indexOf(Supplier);
    this.selectSupplier = Supplier;
    this.selectSupplier = Object.assign({}, this.selectSupplier);  
  }

  okDelete() {
    let tmpSupplierList = [...this.supplierList];
    this.supplierService.deleteSupplier(this.selectSupplier.supplierID)
        .then(() => {
          tmpSupplierList.splice(this.indexOfSupplier, 1);
          this.supplierList = tmpSupplierList;
          this.selectSupplier = null;
        });
  }


  saveSupplier() {
    let tmpSupplierList = [...this.supplierList];
    if (this.isAddSupplier == true) {
      this.supplierService.addSupplier(this.selectSupplier).then(result => {
        tmpSupplierList.push(result);
        this.supplierList = tmpSupplierList;
        this.selectSupplier = null; 
      });
    }
    else {
      this.supplierService.editSupplier(this.selectSupplier.supplierID, this.selectSupplier).then(result => {
        tmpSupplierList[this.indexOfSupplier] = result;
        this.supplierList = tmpSupplierList;
        this.selectSupplier = null; 
      });
    }
    
  }

  cancelSupplier() {
    this.selectSupplier = null;
  }
}
