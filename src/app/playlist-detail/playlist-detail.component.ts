import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Playlist }         from '../playlist';
import { PlaylistService }  from '../playlist.service';

@Component({
  selector: 'app-playlist-detail',
  templateUrl: './playlist-detail.component.html',
  styleUrls: [ './playlist-detail.component.css' ]
})
export class PlaylistDetailComponent implements OnInit {
  playlist: Playlist;

  constructor(
    private route: ActivatedRoute,
    private playlistService: PlaylistService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getPlaylist();
  }

  getPlaylist(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.playlistService.getPlaylist(id)
      .subscribe(playlist => this.playlist = playlist);
  }

  goBack(): void {
    this.location.back();
  }

	save(): void {
		this.playlistService.updatePlaylist(this.playlist).subscribe(() => this.goBack());
	}
}
