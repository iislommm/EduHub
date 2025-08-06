import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ChannelCreateDto, ChannelDto, ChannelUpdateDto } from '../models/channel.model';

@Injectable({
  providedIn: 'root'
})
export class ChannelService {

  constructor(private http: HttpClient) { }

  getAllChannels(): Observable<ChannelDto[]> {
    return this.http.get<ChannelDto[]>(`${environment.apiUrl}/channels`);
  }

  getChannelById(id: number): Observable<ChannelDto> {
    return this.http.get<ChannelDto>(`${environment.apiUrl}/channels/${id}`);
  }

  getChannelByUserId(userId: number): Observable<ChannelDto> {
    return this.http.get<ChannelDto>(`${environment.apiUrl}/channels/user/${userId}`);
  }

  createChannel(channel: ChannelCreateDto): Observable<ChannelDto> {
    return this.http.post<ChannelDto>(`${environment.apiUrl}/channels`, channel);
  }

  updateChannel(id: number, channel: ChannelUpdateDto): Observable<ChannelDto> {
    return this.http.put<ChannelDto>(`${environment.apiUrl}/channels/${id}`, channel);
  }

  deleteChannel(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/channels/${id}`);
  }
}