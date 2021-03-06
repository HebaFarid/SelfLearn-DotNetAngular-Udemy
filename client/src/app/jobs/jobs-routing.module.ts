import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobsComponent } from './jobs.component';
import { JobDetailsComponent } from './job-details/job-details.component';

const routes: Routes = 
[
  {path: '', component: JobsComponent},
  {path: ':id', component: JobDetailsComponent, data: {breadcrumb: {alias: 'jobDetails'}}},
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
export class JobsRoutingModule { }
