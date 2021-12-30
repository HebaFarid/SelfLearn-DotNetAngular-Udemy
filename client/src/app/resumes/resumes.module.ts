import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResumesComponent } from './resumes.component';
import { ResumeItemComponent } from './resume-item/resume-item.component';
import { SharedModule } from '../shared/shared.module';
import { ResumeDetailsComponent } from './resume-details/resume-details.component';
import { ResumesRoutingModule } from './resumes-routing.module';



@NgModule({
  declarations: [
    ResumesComponent,
    ResumeItemComponent,
    ResumeDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ResumesRoutingModule
  ]
})
export class ResumesModule { }
