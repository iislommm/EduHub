import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CommentCreateDto, CommentDto } from '../models/comment.model';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  getCommentsByVideo(videoId: number): Observable<CommentDto[]> {
    return this.http.get<CommentDto[]>(`${environment.apiUrl}/comments/video/${videoId}`);
  }

  createComment(comment: CommentCreateDto): Observable<CommentDto> {
    return this.http.post<CommentDto>(`${environment.apiUrl}/comments`, comment);
  }

  deleteComment(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/comments/${id}`);
  }
}