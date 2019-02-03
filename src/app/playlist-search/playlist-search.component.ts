import { Component, OnInit } from '@angular/core';

import { Observable, Subject } from 'rxjs';

import {
   debounceTime, distinctUntilChanged, switchMap
 } from 'rxjs/operators';

import { Playlist } from '../playlist';
import { PlaylistService } from '../playlist.service';

@Component({
  selector: 'app-playlist-search',
  templateUrl: './playlist-search.component.html',
  styleUrls: [ './playlist-search.component.css' ]
})
export class PlaylistSearchComponent implements OnInit {
  playlists$: Observable<Playlist[]>;
  private searchTerms = new Subject<string>();

  constructor(private playlistService: PlaylistService) {}

  // Push a search term into the observable stream.
  search(term: string): void {
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    this.playlists$ = this.searchTerms.pipe(
      // wait 300ms after each keystroke before considering the term
      debounceTime(300),

      // ignore new term if same as previous term
      distinctUntilChanged(),

      // switch to new search observable each time the term changes
      switchMap((term: string) => this.playlistService.searchPlaylists(term)),
    );
  }
}
