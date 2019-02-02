import { Component, OnInit } from '@angular/core';
import { Playlist } from '../playlist';
import { PlaylistService } from '../playlist.service';

@Component({
  selector: 'app-playlists',
  templateUrl: './playlists.component.html',
  styleUrls: ['./playlists.component.css']
})

export class PlaylistsComponent implements OnInit {

	playlists: Playlist[];

  constructor(private playlistService: PlaylistService) { }

  ngOnInit() {
	this.getPlaylists();
  }

	getPlaylists(): void {
		this.playlistService.getPlaylists()
			.subscribe(playlists => this.playlists = playlists);
	}
}
