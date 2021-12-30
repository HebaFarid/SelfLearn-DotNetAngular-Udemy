import { Component, Input, OnInit } from '@angular/core';
import { IJob } from 'src/app/shared/models/job';

@Component({
  selector: 'app-job-item',
  templateUrl: './job-item.component.html',
  styleUrls: ['./job-item.component.scss']
})
export class JobItemComponent implements OnInit {
  @Input() job: IJob;
  
  constructor() { }

  ngOnInit(): void {
  }

}
