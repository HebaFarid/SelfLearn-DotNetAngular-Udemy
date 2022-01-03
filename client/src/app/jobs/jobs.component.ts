import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IJob } from '../shared/models/job';
import { IJobCategory } from '../shared/models/jobCategory';
import { JobsParams } from '../shared/models/jobsParams';
import { JobsService } from './jobs.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.scss']
})
export class JobsComponent implements OnInit {
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  jobs: IJob[];
  categories: IJobCategory[];
  jobParams = new JobsParams();
  totalCount: number;

  constructor(private jobService: JobsService) { }

  ngOnInit(): void {
    this.getJobs();
    this.getCategories();
  }

  getJobs()
  {
    this.jobService.getJobs(this.jobParams).subscribe(response => {
      this.jobs = response.data;
      this.totalCount = response.count;
      this.jobParams.pageIndex = response.pageIndex;
      this.jobParams.pageSize = response.pageSize;
    }, error => {
      console.log(error);
    });
  }

  getCategories()
  {
    this.jobService.getCategories().subscribe(response => {
      this.categories = [{id: 0, name:'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  onCategorySelected(categoryId: number)
  {
    this.jobParams.categoryId = categoryId;
    this.jobParams.pageIndex = 1;
    this.getJobs();
  }

  onPageChanged(event: any)
  {
    if(this.jobParams.pageIndex !== event)
    {
      this.jobParams.pageIndex = event;
      this.getJobs();
    }
  }

  onSearch()
  {
    this.jobParams.search = this.searchTerm.nativeElement.value;
    this.jobParams.pageIndex = 1;
    this.getJobs();
  }

  onReset()
  {
    this.searchTerm.nativeElement.value = '';
    this.jobParams = new JobsParams();
    this.getJobs();
  }

}
