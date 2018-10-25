import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Order } from "../domain/order";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()
export class OrderService {
    constructor(private http: HttpClient) {} 


    getOrder() {
        return this.http.get("https://localhost:44353/api/Orders")
            .toPromise()
            .then(data => { return data as Order[] })
    }

    addOrder(objEntity: Order) {
        return this.http.post("https://localhost:44353/api/Orders", objEntity)
            .toPromise()
            .then(data => { return data as Order })
    }

    editOrder(id, objEntity: Order) {
        return this.http.put("https://localhost:44353/api/Orders/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Order })
    }

    deleteOrder(id) {
        return this.http.delete("https://localhost:44353/api/Orders/" + id)
            .toPromise()
            .then(() => null);
    }
}