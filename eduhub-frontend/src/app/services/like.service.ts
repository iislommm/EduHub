import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { LikeCreateDto, LikeDto } from '../models/like.model';

@Injectable({
  providedIn: 'root'
})
export class LikeService {

  constructor(private http: HttpClient) { }

  getLikesByVideo(videoId: number): Observable<LikeDto[]> {
    return this.http.get<LikeDto[]>(`${environment.apiUrl}/likes/video/${videoId}`);
  }

  getLikesCount(videoId: number): Observable<number> {
    return this.http.get<number>(`${environment.apiUrl}/likes/video/${videoId}/count`);
  }

  checkUserLike(videoId: number, userId: number): Observable<boolean> {
    return this.http.get<boolean>(`${environment.apiUrl}/likes/video/${videoId}/user/${userId}`);
  }

  likeVideo(like: LikeCreateDto): Observable<LikeDto> {
    return this.http.post<LikeDto>(`${environment.apiUrl}/likes`, like);
  }

  unlikeVideo(videoId: number, userId: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/likes/video/${videoId}/user/${userId}`);
  }
}