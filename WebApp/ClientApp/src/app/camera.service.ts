import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Camera} from './Models/Camera';
import {map} from 'rxjs/operators';
import {CameraDto} from './dtos/CameraDto';

@Injectable({
  providedIn: 'root'
})
export class CameraService {
  private ApiUrl: string;

  constructor(private http: HttpClient) {
    // Normally comes from an injected config service
    this.ApiUrl = 'https://localhost:5001/api/camera';
  }

  public GetCameras(): Observable<Camera[]> {
    return this.http.get<CameraDto[]>(this.ApiUrl)
      .pipe(
        map(camDtos => camDtos.map(dto => this.toCamera(dto))));
  }

  private toCamera(d: CameraDto): Camera {
    return new Camera(d.id, d.camId, d.street, d.latitude, d.longitude);
  }
}
