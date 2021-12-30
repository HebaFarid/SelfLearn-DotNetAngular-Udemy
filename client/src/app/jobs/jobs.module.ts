import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobsComponent } from './jobs.component';
import { JobItemComponent } from './job-item/job-item.component';
import { SharedModule } from '../shared/shared.module';
import { JobDetailsComponent } from './job-details/job-details.component';
import { JobsRoutingModule } from './jobs-routing.module';



@NgModule({
  declarations: [
    JobsComponent,
    JobItemComponent,
    JobDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    JobsRoutingModule
  ]
})
export class JobsModule { }
