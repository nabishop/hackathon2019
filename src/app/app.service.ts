import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Playlist } from './playlist';
import { Observable } from 'rxjs';

@Injectable()
export class AppService {

	protected url: string = '/api/playlists/';

  constructor(private http: HttpClient) {}


  // Rest Items Service: Read all REST Items
  getAll(): Observable<Playlist[]> {
		return this.http.get<Playlist[]>(this.url);
  }

}

