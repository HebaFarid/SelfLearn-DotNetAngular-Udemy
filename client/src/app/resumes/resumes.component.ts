import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IResume } from '../shared/models/resume';
import { IResumeCategory } from '../shared/models/resumeCategory';
import { ResumesParams } from '../shared/models/resumesParams';
import { ResumesService } from './resumes.service';

@Component({
  selector: 'app-resumes',
  templateUrl: './resumes.component.html',
  styleUrls: ['./resumes.component.scss']
})
export class ResumesComponent implements OnInit {
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  resumes: IResume[];
  categories: IResumeCategory[];
  resumeParams = new ResumesParams();
  totalCount: number;

  constructor(private resumeService: ResumesService) { }

  ngOnInit(): void {
    this.getResumes();
    this.getCategories();
  }

  getResumes()
  {    
    this.resumeService.getResumes(this.resumeParams).subscribe(response => {
      this.resumes = response.data;
      this.resumeParams.pageNumber = response.pageIndex;
      this.resumeParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getCategories()
  {
    this.resumeService.getCategories().subscribe(response => {
      this.categories = [{id: 0, name: 'All'}, ...response]; //the "..." is the spread operator
    }, error => {
      console.log(error);
    });
  }

  onCategorySelected(categoryId: number)
  {
    this.resumeParams.categoryId = categoryId;
    this.resumeParams.pageNumber = 1;
    this.getResumes();
  }

  onPageChanged(event: any)
  {    
    if(this.resumeParams.pageNumber !== event)
    {
      this.resumeParams.pageNumber = event;
      this.getResumes();
    }
  }

  onSearch()
  {
    this.resumeParams.search = this.searchTerm.nativeElement.value;
    this.resumeParams.pageNumber = 1;
    this.getResumes();
  }

  onReset()
  {
    this.searchTerm.nativeElement.value = '';
    this.resumeParams = new ResumesParams();
    this.getResumes();
  }

}
