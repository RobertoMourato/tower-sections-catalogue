import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SectionComponent } from './section/section.component';
import { SectionDetailsComponent } from './section-details/section-details.component';

const routes: Routes = [
  { path: 'sections', component: SectionComponent },
  { path: 'section/:id', component: SectionDetailsComponent },
  { path: '', redirectTo: '/sections', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
