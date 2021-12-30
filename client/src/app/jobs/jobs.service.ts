import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { IJob } from '../shared/models/job';
import { IJobCategory } from '../shared/models/jobCategory';
import { IJobPagination } from '../shared/models/jobPagination';
import { JobsParams } from '../shared/models/jobsParams';

@Injectable({
  providedIn: 'root'
})
export class JobsService {
  baseUrl = "https://localhost:5001/api/";

  constructor(private http: HttpClient) { }

  getJobs(jobParams: JobsParams)
  {
    let params = new HttpParams();

    if(jobParams.categoryId !== 0)
    {
      params = params.append('categoryId', jobParams.categoryId.toString());
    }

    params = params.append('pageSize', jobParams.pageSize.toString());
    params = params.append('pageIndex', jobParams.pageIndex.toString());

    if(jobParams.search)
    {
      params = params.append('search', jobParams.search);
    }

    return this.http.get<IJobPagination>(this.baseUrl + "jobs", {observe: 'response', params}).pipe(map(response =>{
        return response.body;
      }));
  }

  getJob(id: number)
  {
    return this.http.get<IJob>(this.baseUrl + 'jobs/' + id);
  }

  getCategories()
  {
    return this.http.get<IJobCategory[]>(this.baseUrl + 'jobs/categories');
  }
}
