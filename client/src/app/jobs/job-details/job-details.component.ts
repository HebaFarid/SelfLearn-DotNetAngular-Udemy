import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IJob } from 'src/app/shared/models/job';
import { JobsService } from '../jobs.service';

@Component({
  selector: 'app-job-details',
  templateUrl: './job-details.component.html',
  styleUrls: ['./job-details.component.scss']
})
export class JobDetailsComponent implements OnInit {
  job: IJob;

  constructor(private jobsService: JobsService, private activaterouter: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadJob();
  }

  loadJob()
  {
    this.jobsService.getJob(+this.activaterouter.snapshot.paramMap.get('id')).subscribe(response => {
      this.job = response;
    }, error => {
      console.log(error);
    });
  }

}
