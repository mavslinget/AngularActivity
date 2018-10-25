import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { OrderDetail } from '../../../domain/orderdetail';
import { Product } from '../../../domain/product';
import { ProductService } from '../../../services/product.service';
import { OrderDetailService } from '../../../services/orderdetail.service';


@Component({
  selector: 'app-order-detail;',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css'],
  providers: [ProductService, OrderDetailService]
})
export class OrderDetailComponent implements OnInit {

  selectOrderDetail: OrderDetail = {} as OrderDetail;
  selectProduct: Product;
  productList: Product[];



  constructor(private fb: FormBuilder, private productService: ProductService,
    private orderDetailService: OrderDetailService) { }

  @Input() orderDetailFormGroup; FormGroup;
  @Input() orderID: string;
  @Output() saveEvent = new EventEmitter();
  ngOnInit() {
    
    this.productService.getProduct().then(product => {
      this.productList = product;
      if (this.orderID) {
      this.orderDetailService.getOrderDetailWithID(this.orderID).then(result => {
        this.selectOrderDetail = result;
        this.selectProduct = this.selectOrderDetail.productID;
      });
    }
    });
  }

  callingSaveEvent() {
    this.saveEvent.emit();
  }


}