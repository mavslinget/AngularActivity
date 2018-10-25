export interface Product {
    productID: string;
    productName: string;
    supplierID: string;
    supplierName: string;
    categoryID: string;
    categoryName: string;
    quantityPerUnit: number;
    unitPrice: number;
    unitsInStock: number;
    unitsInOrder: number;
    reorderLevel: number;
    discontinued: boolean;
}