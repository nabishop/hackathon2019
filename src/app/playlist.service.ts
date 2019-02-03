import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Playlist } from './playlist';
import { MessageService } from './message.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class PlaylistService {

  //private playlistsUrl = '/api/playlist';  // URL to web api
	private playlistsUrl = './mock-playlists.json';

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET playlists from the server */
  getPlaylists (): Observable<Playlist[]> {
    return this.http.get<Playlist[]>(this.playlistsUrl)
      .pipe(
        tap(_ => this.log('fetched playlists')),
        catchError(this.handleError('getPlaylists', []))
      );
  }

  /** GET playlist by id. Return `undefined` when id not found */
  getPlaylistNo404<Data>(id: number): Observable<Playlist> {
    const url = `${this.playlistsUrl}/?id=${id}`;
    return this.http.get<Playlist[]>(url)
      .pipe(
        map(playlists => playlists[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} playlist id=${id}`);
        }),
        catchError(this.handleError<Playlist>(`getPlaylist id=${id}`))
      );
  }

  /** GET playlist by id. Will 404 if id not found */
  getPlaylist(id: number): Observable<Playlist> {
    const url = `${this.playlistsUrl}/${id}`;
    return this.http.get<Playlist>(url).pipe(
      tap(_ => this.log(`fetched playlist id=${id}`)),
      catchError(this.handleError<Playlist>(`getPlaylist id=${id}`))
    );
  }

  /* GET playlists whose name contains search term */
  searchPlaylists(term: string): Observable<Playlist[]> {
    if (!term.trim()) {
      // if not search term, return empty playlist array.
      return of([]);
    }
    return this.http.get<Playlist[]>(`${this.playlistsUrl}/?name=${term}`).pipe(
      tap(_ => this.log(`found playlists matching "${term}"`)),
      catchError(this.handleError<Playlist[]>('searchPlaylists', []))
    );
  }

  //////// Save methods //////////

  /** POST: add a new playlist to the server */
  addPlaylist (playlist: Playlist): Observable<Playlist> {
    return this.http.post<Playlist>(this.playlistsUrl, playlist, httpOptions).pipe(
      tap((playlist: Playlist) => this.log(`added playlist w/ id=${playlist.id}`)),
      catchError(this.handleError<Playlist>('addPlaylist'))
    );
  }

  /** DELETE: delete the playlist from the server */
  deletePlaylist (playlist: Playlist | number): Observable<Playlist> {
    const id = typeof playlist === 'number' ? playlist : playlist.id;
    const url = `${this.playlistsUrl}/${id}`;

    return this.http.delete<Playlist>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted playlist id=${id}`)),
      catchError(this.handleError<Playlist>('deletePlaylist'))
    );
  }

  /** PUT: update the playlist on the server */
  updatePlaylist (playlist: Playlist): Observable<any> {
    return this.http.put(this.playlistsUrl, playlist, httpOptions).pipe(
      tap(_ => this.log(`updated playlist id=${playlist.id}`)),
      catchError(this.handleError<any>('updatePlaylist'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a PlaylistService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`PlaylistService: ${message}`);
  }
}
