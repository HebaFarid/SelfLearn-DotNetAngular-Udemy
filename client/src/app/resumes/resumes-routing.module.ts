import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResumesComponent } from './resumes.component';
import { ResumeDetailsComponent } from './resume-details/resume-details.component';

const routes: Routes =
[
  {path: '', component: ResumesComponent},
  {path: ':id', component: ResumeDetailsComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ResumesRoutingModule { }
