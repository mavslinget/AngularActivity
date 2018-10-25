import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Show } from "../domain/show";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()
export class ShowService {
    constructor(private http: HttpClient) {} 

    getShowWithPagination(page: number, itemsPerPage: number, filter: string) {
        return this.http.get("https://localhost:44353/api/Shows/" + page + "/" + itemsPerPage + "?filter=" + filter)
            .toPromise()
            .then(data => { return data as PaginationResult<Show> })
    }

    getShow() {
        return this.http.get("https://localhost:44353/api/Shows")
            .toPromise()
            .then(data => { return data as Show[] })
    }

    addShow(objEntity: Show) {
        return this.http.post("https://localhost:44353/api/Shows", objEntity)
            .toPromise()
            .then(data => { return data as Show })
    }

    editShow(id, objEntity: Show) {
        return this.http.put("https://localhost:44353/api/Shows/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Show })
    }

    deleteShow(id) {
        return this.http.delete("https://localhost:44353/api/Shows/" + id)
            .toPromise()
            .then(() => null);
    }
}