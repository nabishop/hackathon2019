import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AppService } from './app.service';
import { SafePost } from './safe-post.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{
  title = 'Rhopik';
  posts$: Observable<SafePost[]>;

	constructor(private appService: AppService){
	}

	ngOnInit() {
		this.posts$ = this.getRestItems$();
	}

  getRestItems$(): Observable<SafePost[]> {
    return this.appService.getAll()
      .pipe(posts => posts);
  }
}
