import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { IResume } from '../shared/models/resume';
import { IResumeCategory } from '../shared/models/resumeCategory';
import { IResumePagination } from '../shared/models/resumePagination';
import { ResumesParams } from '../shared/models/resumesParams';

@Injectable({
  providedIn: 'root'
})
export class ResumesService {
  baseUrl = "https://localhost:5001/api/";

  constructor(private http: HttpClient) { }

  getResumes(resumesParams: ResumesParams)
  {
    let params = new HttpParams();

    if(resumesParams.categoryId !== 0)
    {
      params = params.append('categoryId', resumesParams.categoryId.toString());
    }

    
    params = params.append('pageIndex', resumesParams.pageNumber.toString());
    params = params.append('pageSize', resumesParams.pageSize.toString());

    if(resumesParams.search)
    {
      params = params.append('search', resumesParams.search);
    }
    

    //we are using the pipe to extract the bofdy of the http request and project it in an IResumePagination response
    return this.http.get<IResumePagination>(this.baseUrl + "resumes", {observe: 'response', params}).pipe( map(response =>{
      return response.body;
    }));
  }

  getResume(id: number)
  {
    return this.http.get<IResume>(this.baseUrl + 'resumes/' + id);
  }

  getCategories()
  {
    return this.http.get<IResumeCategory[]>(this.baseUrl + 'resumes/categories');
  }

}
