import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Name } from "../domain/name";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()
export class NameService {
    constructor(private http: HttpClient) {} 

    getNameWithPagination(page: number, itemsPerPage: number, filter: string) {
        return this.http.get("https://localhost:44353/api/Names/" + page + "/" + itemsPerPage + "?filter=" + filter)
            .toPromise()
            .then(data => { return data as PaginationResult<Name> })
    }


    getName() {
        return this.http.get("https://localhost:44353/api/Names")
            .toPromise()
            .then(data => { return data as Name[] })
    }

    addName(objEntity: Name) {
        return this.http.post("https://localhost:44353/api/Names", objEntity)
            .toPromise()
            .then(data => { return data as Name })
    }

    editName(id, objEntity: Name) {
        return this.http.put("https://localhost:44353/api/Names/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Name })
    }

    deleteName(id) {
        return this.http.delete("https://localhost:44353/api/Names/" + id)
            .toPromise()
            .then(() => null);
    }
}