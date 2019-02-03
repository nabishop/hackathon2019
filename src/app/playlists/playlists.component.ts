import { Component, OnInit } from '@angular/core';
import { Playlist } from '../playlist';
import { PlaylistService } from '../playlist.service';

@Component({
  selector: 'app-playlists',
  templateUrl: './playlists.component.html',
  styleUrls: ['./playlists.component.css']
})

export class PlaylistsComponent implements OnInit {

	public playlists = [];			//local playlists property built from db

  constructor(private playlistService: PlaylistService) { }

  ngOnInit() {
	this.playlistService.getPlaylists().subscribe(data => this.playlists = data);
  }

}
