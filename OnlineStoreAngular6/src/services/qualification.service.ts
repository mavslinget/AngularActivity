import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Qualification } from "../domain/qualification";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()
export class QualificationService {
    constructor(private http: HttpClient) {} 

    getQualificationWithPagination(page: number, itemsPerPage: number, filter: string) {
        return this.http.get("https://localhost:44353/api/Qualifications/" + page + "/" + itemsPerPage + "?filter=" + filter)
            .toPromise()
            .then(data => { return data as PaginationResult<Qualification> })
    }

    getQualification() {
        return this.http.get("https://localhost:44353/api/Qualifications")
            .toPromise()
            .then(data => { return data as Qualification[] })
    }

    addQualification(objEntity: Qualification) {
        return this.http.post("https://localhost:44353/api/Qualifications", objEntity)
            .toPromise()
            .then(data => { return data as Qualification })
    }

    editQualification(id, objEntity: Qualification) {
        return this.http.put("https://localhost:44353/api/Qualifications/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Qualification })
    }

    deleteQualification(id) {
        return this.http.delete("https://localhost:44353/api/Qualifications/" + id)
            .toPromise()
            .then(() => null);
    }
}