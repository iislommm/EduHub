import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { VideoCreateDto, VideoGetDto, VideoUpdateDto } from '../models/video.model';

@Injectable({
  providedIn: 'root'
})
export class VideoService {

  constructor(private http: HttpClient) { }

  getAllVideos(): Observable<VideoGetDto[]> {
    return this.http.get<VideoGetDto[]>(`${environment.apiUrl}/videos`);
  }

  getVideoById(id: number): Observable<VideoGetDto> {
    return this.http.get<VideoGetDto>(`${environment.apiUrl}/videos/${id}`);
  }

  getVideosByCategory(categoryId: number): Observable<VideoGetDto[]> {
    return this.http.get<VideoGetDto[]>(`${environment.apiUrl}/videos/category/${categoryId}`);
  }

  getVideosByInstructor(instructorId: number): Observable<VideoGetDto[]> {
    return this.http.get<VideoGetDto[]>(`${environment.apiUrl}/videos/instructor/${instructorId}`);
  }

  searchVideos(query: string, categoryId?: number): Observable<VideoGetDto[]> {
    let params = new HttpParams().set('query', query);
    if (categoryId) {
      params = params.set('categoryId', categoryId.toString());
    }
    return this.http.get<VideoGetDto[]>(`${environment.apiUrl}/videos/search`, { params });
  }

  getFeaturedVideos(): Observable<VideoGetDto[]> {
    return this.http.get<VideoGetDto[]>(`${environment.apiUrl}/videos/featured`);
  }

  createVideo(video: VideoCreateDto): Observable<VideoGetDto> {
    return this.http.post<VideoGetDto>(`${environment.apiUrl}/videos`, video);
  }

  updateVideo(id: number, video: VideoUpdateDto): Observable<VideoGetDto> {
    return this.http.put<VideoGetDto>(`${environment.apiUrl}/videos/${id}`, video);
  }

  deleteVideo(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/videos/${id}`);
  }

  incrementViews(id: number): Observable<void> {
    return this.http.post<void>(`${environment.apiUrl}/videos/${id}/view`, {});
  }
}