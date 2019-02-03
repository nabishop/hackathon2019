import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AppService } from './app.service';
import { Playlist } from './playlist';

import { interval } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{
  title = 'Rhopik';
	interval_MSEC = 10000;
  playlistsVoid$$: Observable<Observable<void>>;
	playlists: Playlist[];

	constructor(private appService: AppService){
	}

	ngOnInit() {
		this.playlistsVoid$$ = this.getRestItemsIntervalVoid$$();
	}

  getRestItemsIntervalVoid$$(): Observable<Observable<void>> {
    return interval(this.interval_MSEC)
      .pipe(
        map(
          counter => {
            console.log(counter + ': read restItems');
            return this.assignRestItemsToPlaylists$();
          }
        )
      );
  }

  assignRestItemsToPlaylists$(): Observable<void> {
    return this.appService.getAll().pipe(
      map(playlists => {
        this.playlists = playlists;
      }));
  }
}
