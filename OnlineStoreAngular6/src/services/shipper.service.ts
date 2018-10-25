import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Shipper } from "../domain/shipper";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()
export class ShipperService {
    constructor(private http: HttpClient) {} 

    getShipperWithPagination(page: number, itemsPerPage: number, filter: string) {
        return this.http.get("https://localhost:44353/api/Shippers/" + page + "/" + itemsPerPage + "?filter=" + filter)
            .toPromise()
            .then(data => { return data as PaginationResult<Shipper> })
    }

    getShipper() {
        return this.http.get("https://localhost:44353/api/Shippers")
            .toPromise()
            .then(data => { return data as Shipper[] })
    }

    addShipper(objEntity: Shipper) {
        return this.http.post("https://localhost:44353/api/Shippers", objEntity)
            .toPromise()
            .then(data => { return data as Shipper })
    }

    editShipper(id, objEntity: Shipper) {
        return this.http.put("https://localhost:44353/api/Shippers/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Shipper })
    }

    deleteShipper(id) {
        return this.http.delete("https://localhost:44353/api/Shippers/" + id)
            .toPromise()
            .then(() => null);
    }
}