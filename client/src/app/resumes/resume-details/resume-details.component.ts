import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IResume } from 'src/app/shared/models/resume';
import { ResumesService } from '../resumes.service';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-resume-details',
  templateUrl: './resume-details.component.html',
  styleUrls: ['./resume-details.component.scss']
})
export class ResumeDetailsComponent implements OnInit {
  resume: IResume;

  constructor(private resumesService: ResumesService, private activateRoute: ActivatedRoute, private bcService: BreadcrumbService) { 
    this.bcService.set('@resumeDetails', ' ');
  }

  ngOnInit(): void {
    this.loadResume();
  }

  loadResume()
  {
    //we added a '+' to change the string to integer
    this.resumesService.getResume(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(response => {
      this.resume = response;  
      this.bcService.set('@resumeDetails', response.name);    
    }, error =>{
      console.log(error);
    });
  }

}
