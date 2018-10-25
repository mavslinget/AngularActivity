import { Component, OnInit, ViewChild } from '@angular/core';
import { Customer } from '../../domain/customer';
import { CustomerService } from '../../services/customer.service';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { DataTable } from 'primeng/primeng';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  providers: [CustomerService]
})
export class CustomerComponent implements OnInit {
  customerList: Customer[];
  selectCustomer: Customer;
  customerForm: FormGroup;
  isAddCustomer: boolean;
  indexOfCustomer: number = 0;
  isDeleteCustomer: boolean;
  totalRecords: number = 0;
  searchCustomerName: string = "";

  constructor(private customerService: CustomerService, private fb: FormBuilder) { }

  @ViewChild('dt') public dataTable: DataTable;    
  ngOnInit() {
    this.customerForm = this.fb.group({
      'companyName': new FormControl('', Validators.required),
      'contactName': new FormControl('', Validators.required),
      'contactTitle': new FormControl('', Validators.required),
      'address': new FormControl('', Validators.required),
      'city': new FormControl('', Validators.required),
      'region': new FormControl('', Validators.required),
      'postalCode': new FormControl('', Validators.required),
      'country': new FormControl('', Validators.required),
      'phone': new FormControl('', Validators.required),
      'fax': new FormControl('', Validators.required)
    });

    this.loadAllCustomers();
  }

  loadAllCustomers() {
    this.customerService.getCustomer().then(result => {
      this.customerList = result;
    })
  }

  paginate($event) {
    //event.first = Index of the first record
    //event.rows = Number of rows to display in new page
    //event.page = Index of the new page
    //event.pageCount = Total number of pages

    this.customerService.getCustomerWithPagination($event.first, $event.rows, this.searchCustomerName)
      .then(result => {
        this.totalRecords = result.totalRecords;
        this.customerList = result.results;

      })
  }

  searchCustomer() {
    if(this.searchCustomerName.length != 1) {
      this.resetTable();
    }
  }

  resetTable() {
    this.dataTable.reset();
  }


  addCustomer() {
    this.customerForm.enable();
    this.isDeleteCustomer = false;
    this.isAddCustomer = true;
    this.selectCustomer = {} as Customer;
    
  }

 
  editCustomer(Customer) {
    this.customerForm.enable();
    this.isDeleteCustomer = false;
    this.isAddCustomer = false;
    this.indexOfCustomer = this.customerList.indexOf(Customer);
    this.selectCustomer = Customer;
    this.selectCustomer = Object.assign({}, this.selectCustomer);    
  }

  deleteCustomer(Customer) {
    this.customerForm.disable();
    this.isDeleteCustomer = true;
    this.indexOfCustomer = this.customerList.indexOf(Customer);
    this.selectCustomer = Customer;
    this.selectCustomer = Object.assign({}, this.selectCustomer);  
  }

  okDelete() {
    let tmpCustomerList = [...this.customerList];
    this.customerService.deleteCustomer(this.selectCustomer.customerID)
        .then(() => {
          tmpCustomerList.splice(this.indexOfCustomer, 1);
          this.customerList = tmpCustomerList;
          this.selectCustomer = null;
        });
  }


  saveCustomer() {
    let tmpCustomerList = [...this.customerList];
    if (this.isAddCustomer == true) {
      this.customerService.addCustomer(this.selectCustomer).then(result => {
        tmpCustomerList.push(result);
        this.customerList = tmpCustomerList;
        this.selectCustomer = null; 
      });
    }
    else {
      this.customerService.editCustomer(this.selectCustomer.customerID, this.selectCustomer).then(result => {
        tmpCustomerList[this.indexOfCustomer] = result;
        this.customerList = tmpCustomerList;
        this.selectCustomer = null; 
      });
    }
    
  }

  cancelCustomer() {
    this.selectCustomer = null;
  }
}
