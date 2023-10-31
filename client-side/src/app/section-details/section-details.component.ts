import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SectionDetailsService } from './section-details.service';

@Component({
  selector: 'app-section-details',
  templateUrl: './section-details.component.html',
  styleUrls: ['./section-details.component.css']
})
export class SectionDetailsComponent implements OnInit {
  sectionInformation: any;

  constructor(
    private route: ActivatedRoute,
    private sectionDetailsService: SectionDetailsService
  ) { }

  ngOnInit(): void {
    const sectionId = this.route.snapshot.paramMap.get('id');

    this.sectionDetailsService.getSection(sectionId).subscribe((data) => {
      this.sectionInformation = data;
    });
  }
}