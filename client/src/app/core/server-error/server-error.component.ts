import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.scss']
})
export class ServerErrorComponent implements OnInit {
  error: any;

  constructor(private router: Router) 
  {
    const navigation  = this.router.getCurrentNavigation();
    this.error = navigation?.extras?.state?.error; // you only get one time access to this when you are navigating through the root, there are other ways to persist it but you nee to check that
  }

  ngOnInit(): void {
  }

}
