import { Component, Input, OnInit } from '@angular/core';
import { IResume } from 'src/app/shared/models/resume';

@Component({
  selector: 'app-resume-item',
  templateUrl: './resume-item.component.html',
  styleUrls: ['./resume-item.component.scss']
})
export class ResumeItemComponent implements OnInit {
  @Input() resume: IResume;
  
  constructor() { }

  ngOnInit(): void {
  }

}
