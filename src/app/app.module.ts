// imports
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppService } from './app.service';
import { PlaylistsComponent } from './playlists/playlists.component';
import { PlaylistDetailComponent } from './playlist-detail/playlist-detail.component';
import { AppRoutingModule } from './app-routing.module';


// @NgModule decorator with its metadata
@NgModule({
  declarations: [
    AppComponent,
	 DashboardComponent,
    PlaylistsComponent,
    PlaylistDetailComponent
  ],
  imports: [
    FormsModule,
    HttpClientModule,
	BrowserModule,
	AppRoutingModule
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
