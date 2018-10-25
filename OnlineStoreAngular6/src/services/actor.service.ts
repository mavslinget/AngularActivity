import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Actor } from "../domain/actor";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()
export class ActorService {
    constructor(private http: HttpClient) {} 

    getActorWithPagination(page: number, itemsPerPage: number, filter: string) {
        return this.http.get("https://localhost:44353/api/Actors/" + page + "/" + itemsPerPage + "?filter=" + filter)
            .toPromise()
            .then(data => { return data as PaginationResult<Actor> })
    }

    getActor() {
        return this.http.get("https://localhost:44353/api/Actors")
            .toPromise()
            .then(data => { return data as Actor[] })
    }

    addActor(objEntity: Actor) {
        return this.http.post("https://localhost:44353/api/Actors", objEntity)
            .toPromise()
            .then(data => { return data as Actor })
    }

    editActor(id, objEntity: Actor) {
        return this.http.put("https://localhost:44353/api/Actors/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Actor })
    }

    deleteActor(id) {
        return this.http.delete("https://localhost:44353/api/Actors/" + id)
            .toPromise()
            .then(() => null);
    }
}