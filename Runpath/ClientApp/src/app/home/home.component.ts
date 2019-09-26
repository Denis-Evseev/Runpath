import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public userId: any = 1;
  public jsonResult: any;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    http.get<any>(baseUrl + 'api/Albums/GetAllAlbumsAndPhotos/' + this.userId).subscribe(result => {
      this.jsonResult = result;
    }, error => console.error(error));
  }

  public downloadAlbumAndPhotos() {
    this.http.get<any>(this.baseUrl + 'api/Albums/GetAllAlbumsAndPhotos/' + this.userId).subscribe(result => {
      this.jsonResult = result;
    }, error => console.error(error));
  }

  public setUserId(userId: number) {
    this.userId = userId;
  }
}

