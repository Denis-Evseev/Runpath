import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

import { Album } from '../models/album';

@Component({
  selector: 'app-home',
  templateUrl: './albums.component.html',
})
export class AlbumsComponent {

  public userId: string;
  public albums: Album[];

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string,
    router: Router, private activatedRoute: ActivatedRoute) {

    this.userId = this.activatedRoute.snapshot.url[1].toString();

    http.get<Album[]>(baseUrl + 'api/Albums/GetAlbumsByUserId/' + this.userId).subscribe(result => {
      this.albums = result;
    }, error => console.error(error));
  }
}

