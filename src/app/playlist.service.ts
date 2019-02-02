import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';

import { Playlist } from './playlist';
import { PLAYLISTS } from './mock-playlists';

@Injectable({
  providedIn: 'root',
})
export class PlaylistService {

  constructor() { }

  getPlaylists(): Observable<Playlist[]> {
    return of(PLAYLISTS);
  }

  getPlaylist(id: number): Observable<Playlist> {
    return of(PLAYLISTS.find(playlist => playlist.id === id));
  }

}
