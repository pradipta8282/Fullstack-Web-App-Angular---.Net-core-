import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { Observable, Observer } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { category } from '../models/category.model';
import { enviroment } from 'src/enviroments/environment';
import { UpdateCategotyRequest } from '../models/update-category-request-model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  addCategory(model : AddCategoryRequest) : Observable<void>
  {
    return this.http.post<void>(`${enviroment.apiBaseUrl}/api/categories`,model);

  }
  getAllCategories(): Observable<category[]>{
    return this.http.get<category[]>(`${enviroment.apiBaseUrl}/api/categories`);

  }
  getCategoryByID(id: string): Observable<category>{
    return this.http.get<category>(`${enviroment.apiBaseUrl}/api/categories/${id}`);
  }

  updateCategory(id: string , UpdateCategotyRequest: UpdateCategotyRequest) : Observable<category> {
   return this.http.put<category>(`${enviroment.apiBaseUrl}/api/categories/${id}`,UpdateCategotyRequest);

  }
}
