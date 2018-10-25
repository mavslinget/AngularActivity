import { Component, OnInit, ViewChild } from '@angular/core';
import { Product } from '../../domain/product';
import { Category } from '../../domain/category';
import { Supplier } from '../../domain/supplier';
import { ProductService } from '../../services/product.service';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { DataTable } from 'primeng/primeng';
import { SupplierService } from '../../services/supplier.service';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService, SupplierService, CategoryService]
})
export class ProductComponent implements OnInit {
  productList: Product[];
  selectProduct: Product;
  productForm: FormGroup;
  isAddProduct: boolean;
  indexOfProduct: number = 0;
  isDeleteProduct: boolean;
  supplierList: Supplier[];
  selectSupplier: Supplier;
  categoryList: Category[];
  selectCategory: Category;
  // totalRecords: number = 0;
  // searchProductName: string = "";

  constructor(private productService: ProductService, private fb: FormBuilder,
    private supplierService: SupplierService, private categoryService: CategoryService) { }

  @ViewChild('dt') public dataTable: DataTable;
  ngOnInit() {
    this.productForm = this.fb.group({
      'supplier': new FormControl('', Validators.required),
      'category': new FormControl('', Validators.required),
      'productName': new FormControl('', Validators.required),
      'quantityPerUnit': new FormControl('', Validators.required),
      'unitPrice': new FormControl('', Validators.required),
      'unitsInStock': new FormControl('', Validators.required),
      'reorderLevel': new FormControl('', Validators.required),
      'discontinued': new FormControl('', Validators.required),
      
    });

    this.loadAllProducts();
  }

  loadAllProducts() {

    this.categoryService.getCategory().then(categories => {
      this.categoryList = categories;
      this.supplierService.getSupplier().then(suppliers => {
        this.supplierList = suppliers;
        this.productService.getProduct().then(result => {
          this.productList = result;

          for(var i = 0 ; i < this.productList.length; i++){
            this.productList[i].supplierName = this.supplierList.find(su => su.supplierID == 
              this.productList[i].supplierID).companyName;
              this.productList[i].categoryName = this.categoryList.find(su => su.categoryID == 
                this.productList[i].categoryID).categoryName;  
          }
        })
      });
    });

    
  }

  // paginate($event) {
  //   //event.first = Index of the first record
  //   //event.rows = Number of rows to display in new page
  //   //event.page = Index of the new page
  //   //event.pageCount = Total number of pages

  //   this.productService.getProductWithPagination($event.first, $event.rows, this.searchProductName)
  //     .then(result => {
  //       this.totalRecords = result.totalRecords;
  //       this.productList = result.results;

  //     })
  // }

  // searchProduct() {
  //   if(this.searchProductName.length != 1) {
  //     this.resetTable();
  //   }
  // }

  // resetTable() {
  //   this.dataTable.reset();
  // }

  addProduct() {
    this.productForm.enable();
    this.isDeleteProduct = false;
    this.isAddProduct = true;
    this.selectProduct = {} as Product;
    this.selectCategory = {} as Category;
    this.selectSupplier = {} as Supplier;
    
  }

 
  editProduct(Product) {
    this.productForm.enable();
    this.isDeleteProduct = false;
    this.indexOfProduct = this.productList.indexOf(Product);
    this.isAddProduct = false;
    this.selectProduct = Product;

    this.selectCategory = this.categoryList.find(su => su.categoryID == this.selectProduct.categoryID);
    this.selectSupplier = this.supplierList.find(su => su.supplierID == this.selectSupplier.supplierID);
    this.selectProduct = Object.assign({}, this.selectProduct);    
  }

  deleteProduct(Product) {
    this.productForm.disable();
    this.isDeleteProduct = true;
    this.indexOfProduct = this.productList.indexOf(Product);
    this.selectProduct = Product;

    this.selectCategory = this.categoryList.find(su => su.categoryID == this.selectProduct.categoryID);
    this.selectSupplier = this.supplierList.find(su => su.supplierID == this.selectSupplier.supplierID);
    this.selectProduct = Object.assign({}, this.selectProduct);  
  }

  okDelete() {
    let tmpProductList = [...this.productList];
    this.productService.deleteProduct(this.selectProduct.productID)
        .then(() => {
          tmpProductList.splice(this.indexOfProduct, 1);
          this.productList = tmpProductList;
          this.selectProduct = null;
        });
  }


  saveProduct() {
    let tmpProductList = [...this.productList];

    this.selectProduct.supplierID = this.selectSupplier.supplierID;
    this.selectProduct.categoryID = this.selectCategory.categoryID;

    if (this.isAddProduct == true) {
      this.productService.addProduct(this.selectProduct).then(result => {
        tmpProductList.push(result);
        this.productList = tmpProductList;

        for(var i = 0 ; i < this.productList.length; i++){
          this.productList[i].supplierName = this.supplierList.find(su => su.supplierID == 
            this.productList[i].supplierID).companyName;
            this.productList[i].categoryName = this.categoryList.find(su => su.categoryID == 
              this.productList[i].categoryID).categoryName;  
        }

        this.selectProduct = null; 
      });
    }
    else {
      this.productService.editProduct(this.selectProduct.productID, this.selectProduct).then(result => {
        tmpProductList[this.indexOfProduct] = result;
        this.productList = tmpProductList;

        for(var i = 0 ; i < this.productList.length; i++){
          this.productList[i].supplierName = this.supplierList.find(su => su.supplierID == 
            this.productList[i].supplierID).companyName;
            this.productList[i].categoryName = this.categoryList.find(su => su.categoryID == 
              this.productList[i].categoryID).categoryName;  
        }
        
        this.selectProduct = null; 
      });
    }
    
  }

  cancelProduct() {
    this.selectProduct = null;
  }
}
