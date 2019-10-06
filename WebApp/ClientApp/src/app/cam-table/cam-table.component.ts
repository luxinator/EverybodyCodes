import {Component, OnInit} from '@angular/core';
import {CameraService} from '../camera.service';
import {Camera} from '../Models/Camera';

@Component({
  selector: 'app-cam-table',
  templateUrl: './cam-table.component.html',
  styleUrls: ['./cam-table.component.css']
})
export class CamTableComponent implements OnInit {
  private Cams3: Camera[] = [];
  private Cams5: Camera[] = [];
  private Cams35: Camera[] = [];
  private CamsOther: Camera[] = [];

  constructor(private cameraService: CameraService) {
  }

  ngOnInit() {
    this.cameraService.GetCameras().subscribe(c => this.SortCams(c));
  }

  SortCams(Cams: Camera[]) {
    // Match on nr
    const idMatcher = new RegExp('\\d{3}');

    Cams.forEach((cam) => {
      const idNumber = Number(idMatcher.exec(cam.CamId)[0]);

      if (idNumber % 3 === 0) {
        this.Cams3.push(cam);
      } else if (idNumber % 5 === 0) {
        this.Cams5.push(cam);
      } else if (idNumber % 3 === 0 && idNumber % 5 === 0) {
        this.Cams35.push(cam);
      } else {
        this.CamsOther.push(cam);
      }
    });
  }
}
