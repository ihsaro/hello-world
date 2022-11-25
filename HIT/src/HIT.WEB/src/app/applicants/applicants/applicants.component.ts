import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApplicantsService } from 'src/app/core/services/applicants/applicants.service';
import { ApplicationPhase } from 'src/app/shared/enum/ApplicationPhase';

@Component({
  selector: 'app-applicants',
  templateUrl: './applicants.component.html',
  styleUrls: ['./applicants.component.css']
})
export class ApplicantsComponent implements OnInit {
  public id!: number;
  constructor(route: ActivatedRoute, public applicationsService: ApplicantsService) { 
    route.params.subscribe((params) => {
      this.id = params["id"];
    });

  }

  ngOnInit(): void {
  }

}
