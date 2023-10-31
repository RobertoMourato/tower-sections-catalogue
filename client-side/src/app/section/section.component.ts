import { Component, OnInit } from '@angular/core';
import { SectionService } from './section.service';

@Component({
  selector: 'app-section',
  templateUrl: './section.component.html',
  styleUrls: ['./section.component.css']
})
export class SectionComponent implements OnInit {
  sections: any[] = [];

  constructor(private sectionService: SectionService) { }

  ngOnInit(): void {
    this.sectionService.getSections().subscribe((data) => {
      this.sections = data;
    });
  }
}