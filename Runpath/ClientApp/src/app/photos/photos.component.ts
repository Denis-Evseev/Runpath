import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

import { Photo } from '../models/photo';

@Component({
  selector: 'app-home',
  templateUrl: './photos.component.html',
})
export class PhotosComponent {

  public albumId: string;
  public photos: Photo[];

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string,
    router: Router, private activatedRoute: ActivatedRoute) {

    this.albumId = this.activatedRoute.snapshot.url[1].toString();

    http.get<Photo[]>(baseUrl + 'api/Photos/GetPhotosByAlbumId/' + this.albumId).subscribe(result => {
      this.photos = result;
    }, error => console.error(error));
  }
}

