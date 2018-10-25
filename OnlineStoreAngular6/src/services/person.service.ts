import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Person } from "../domain/person";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()
export class PersonService {
    constructor(private http: HttpClient) {} 

    getPersonWithPagination(page: number, itemsPerPage: number, filter: string) {
        return this.http.get("https://localhost:44353/api/Persons/" + page + "/" + itemsPerPage + "?filter=" + filter)
            .toPromise()
            .then(data => { return data as PaginationResult<Person> })
    }

    getPerson() {
        return this.http.get("https://localhost:44353/api/Persons")
            .toPromise()
            .then(data => { return data as Person[] })
    }

    addPerson(objEntity: Person) {
        return this.http.post("https://localhost:44353/api/Persons", objEntity)
            .toPromise()
            .then(data => { return data as Person })
    }

    editPerson(id, objEntity: Person) {
        return this.http.put("https://localhost:44353/api/Persons/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Person })
    }

    deletePerson(id) {
        return this.http.delete("https://localhost:44353/api/Persons/" + id)
            .toPromise()
            .then(() => null);
    }
}