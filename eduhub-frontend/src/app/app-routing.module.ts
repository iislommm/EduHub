import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Components
import { HomepageComponent } from './components/homepage/homepage.component';
import { LoginComponent } from './components/auth/login.component';
import { SignupComponent } from './components/auth/signup.component';

// Guards
import { AuthGuard } from './guards/auth.guard';
import { AdminGuard } from './guards/admin.guard';

const routes: Routes = [
  // Public routes
  { path: '', component: HomepageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'about', loadChildren: () => import('./components/about/about.module').then(m => m.AboutModule) },
  
  // Protected routes (require authentication)
  { 
    path: 'profile', 
    loadChildren: () => import('./components/profile/profile.module').then(m => m.ProfileModule),
    canActivate: [AuthGuard]
  },
  { 
    path: 'video', 
    loadChildren: () => import('./components/video/video.module').then(m => m.VideoModule),
    canActivate: [AuthGuard]
  },
  { 
    path: 'channel', 
    loadChildren: () => import('./components/channel/channel.module').then(m => m.ChannelModule),
    canActivate: [AuthGuard]
  },
  { 
    path: 'search', 
    loadChildren: () => import('./components/search/search.module').then(m => m.SearchModule),
    canActivate: [AuthGuard]
  },
  
  // Admin routes (require admin role)
  { 
    path: 'admin', 
    loadChildren: () => import('./components/admin/admin.module').then(m => m.AdminModule),
    canActivate: [AuthGuard, AdminGuard]
  },
  
  // Fallback route
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }