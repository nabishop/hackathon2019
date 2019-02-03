import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppService } from './app.service';
import { PlaylistsComponent } from './playlists/playlists.component';
import { PlaylistDetailComponent } from './playlist-detail/playlist-detail.component';
import { PlaylistSearchComponent }  from './playlist-search/playlist-search.component';

import { AppRoutingModule } from './app-routing.module';
import { MessagesComponent } from './messages/messages.component';

import { LoginComponent } from './login/login.component';
import { routing } from './app-routing.module';
import { AuthenticationService } from './auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { UserService } from './user.service';

import { AddUserComponent } from './add-user/add-user.component';
import { ListUserComponent } from './list-user/list-user.component';
import { EditUserComponent } from './edit-user/edit-user.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CustomMaterialModule }  from './material/material.module';

// @NgModule decorator with its metadata
@NgModule({
  declarations: [
    AppComponent,
	 DashboardComponent,
    PlaylistsComponent,
    PlaylistDetailComponent,
	 PlaylistSearchComponent,
    MessagesComponent,
    LoginComponent,
    AddUserComponent,
    ListUserComponent,
    EditUserComponent,
    PlaylistSearchComponent
  ],
  imports: [
    FormsModule,
	 routing,
	ReactiveFormsModule,
    HttpClientModule,
	BrowserModule,
	AppRoutingModule,
	BrowserAnimationsModule,
	CustomMaterialModule
  ],
  providers: [AuthenticationService, UserService, AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
