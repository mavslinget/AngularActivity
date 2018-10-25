import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Supplier } from "../domain/supplier";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()
export class SupplierService {
    constructor(private http: HttpClient) {} 

    getSupplierWithPagination(page: number, itemsPerPage: number, filter: string) {
        return this.http.get("https://localhost:44353/api/Suppliers/" + page + "/" + itemsPerPage + "?filter=" + filter)
            .toPromise()
            .then(data => { return data as PaginationResult<Supplier> })
    }

    getSupplier() {
        return this.http.get("https://localhost:44353/api/Suppliers")
            .toPromise()
            .then(data => { return data as Supplier[] })
    }

    addSupplier(objEntity: Supplier) {
        return this.http.post("https://localhost:44353/api/Suppliers", objEntity)
            .toPromise()
            .then(data => { return data as Supplier })
    }

    editSupplier(id, objEntity: Supplier) {
        return this.http.put("https://localhost:44353/api/Suppliers/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Supplier })
    }

    deleteSupplier(id) {
        return this.http.delete("https://localhost:44353/api/Suppliers/" + id)
            .toPromise()
            .then(() => null);
    }
}