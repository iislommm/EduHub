import { Component } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent {
  teamMembers = [
    {
      name: 'EduHub Team',
      role: 'Education Platform Creators',
      description: 'We are passionate about making quality education accessible to everyone.',
      icon: 'fas fa-users'
    }
  ];
}