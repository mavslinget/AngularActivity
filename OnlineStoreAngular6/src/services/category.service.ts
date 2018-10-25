import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Category } from "../domain/category";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()
export class CategoryService {
    constructor(private http: HttpClient) {} 

    getCategoryWithPagination(page: number, itemsPerPage: number, filter: string) {
        return this.http.get("https://localhost:44353/api/Categories/" + page + "/" + itemsPerPage + "?filter=" + filter)
            .toPromise()
            .then(data => { return data as PaginationResult<Category> })
    }

    getCategory() {
        return this.http.get("https://localhost:44353/api/Categories")
            .toPromise()
            .then(data => { return data as Category[] })
    }

    addCategory(objEntity: Category) {
        return this.http.post("https://localhost:44353/api/Categories", objEntity)
            .toPromise()
            .then(data => { return data as Category })
    }

    editCategory(id, objEntity: Category) {
        return this.http.put("https://localhost:44353/api/Categories/" + id, objEntity)
            .toPromise()
            .then(data => { return data as Category })
    }

    deleteCategory(id) {
        return this.http.delete("https://localhost:44353/api/Categories/" + id)
            .toPromise()
            .then(() => null);
    }
}