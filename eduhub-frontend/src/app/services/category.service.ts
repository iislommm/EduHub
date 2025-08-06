import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CategoryCreateDto, CategoryDto, CategoryUpdateDto } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  getAllCategories(): Observable<CategoryDto[]> {
    return this.http.get<CategoryDto[]>(`${environment.apiUrl}/categories`);
  }

  getCategoryById(id: number): Observable<CategoryDto> {
    return this.http.get<CategoryDto>(`${environment.apiUrl}/categories/${id}`);
  }

  createCategory(category: CategoryCreateDto): Observable<CategoryDto> {
    return this.http.post<CategoryDto>(`${environment.apiUrl}/categories`, category);
  }

  updateCategory(id: number, category: CategoryUpdateDto): Observable<CategoryDto> {
    return this.http.put<CategoryDto>(`${environment.apiUrl}/categories/${id}`, category);
  }

  deleteCategory(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/categories/${id}`);
  }
}