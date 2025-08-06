import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { VideoService } from '../../services/video.service';
import { CategoryService } from '../../services/category.service';
import { VideoGetDto } from '../../models/video.model';
import { CategoryDto } from '../../models/category.model';
import { UserGetDto } from '../../models/user.model';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent implements OnInit {
  currentUser: UserGetDto | null = null;
  featuredVideos: VideoGetDto[] = [];
  categories: CategoryDto[] = [];
  selectedCategoryId: number | null = null;
  filteredVideos: VideoGetDto[] = [];
  searchQuery: string = '';
  loading: boolean = true;

  constructor(
    private authService: AuthService,
    private videoService: VideoService,
    private categoryService: CategoryService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.authService.currentUser$.subscribe(user => {
      this.currentUser = user;
    });

    this.loadData();
  }

  loadData(): void {
    this.loading = true;
    
    // Load categories
    this.categoryService.getAllCategories().subscribe({
      next: (categories) => {
        this.categories = categories;
      },
      error: (error) => console.error('Error loading categories:', error)
    });

    // Load featured videos
    this.videoService.getFeaturedVideos().subscribe({
      next: (videos) => {
        this.featuredVideos = videos.slice(0, 6); // Show only first 6
        if (!this.currentUser) {
          this.filteredVideos = videos.slice(0, 9); // Show 9 preview videos for non-logged users
        }
        this.loading = false;
      },
      error: (error) => {
        console.error('Error loading featured videos:', error);
        // Fallback to all videos if featured endpoint doesn't exist
        this.videoService.getAllVideos().subscribe({
          next: (videos) => {
            this.featuredVideos = videos.slice(0, 6);
            if (!this.currentUser) {
              this.filteredVideos = videos.slice(0, 9);
            }
            this.loading = false;
          },
          error: (err) => {
            console.error('Error loading videos:', err);
            this.loading = false;
          }
        });
      }
    });

    // If user is logged in, load all videos
    if (this.currentUser) {
      this.videoService.getAllVideos().subscribe({
        next: (videos) => {
          this.filteredVideos = videos;
        },
        error: (error) => console.error('Error loading all videos:', error)
      });
    }
  }

  onCategorySelect(categoryId: number): void {
    this.selectedCategoryId = categoryId;
    this.searchQuery = '';
    
    if (this.currentUser) {
      this.videoService.getVideosByCategory(categoryId).subscribe({
        next: (videos) => {
          this.filteredVideos = videos;
        },
        error: (error) => console.error('Error loading category videos:', error)
      });
    }
  }

  onSearch(): void {
    if (this.searchQuery.trim()) {
      if (this.currentUser) {
        this.videoService.searchVideos(this.searchQuery, this.selectedCategoryId || undefined).subscribe({
          next: (videos) => {
            this.filteredVideos = videos;
          },
          error: (error) => console.error('Error searching videos:', error)
        });
      } else {
        // For non-logged users, filter from existing preview videos
        this.filteredVideos = this.featuredVideos.filter(video =>
          video.name.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
          video.description.toLowerCase().includes(this.searchQuery.toLowerCase())
        );
      }
    }
  }

  clearFilters(): void {
    this.selectedCategoryId = null;
    this.searchQuery = '';
    
    if (this.currentUser) {
      this.videoService.getAllVideos().subscribe({
        next: (videos) => {
          this.filteredVideos = videos;
        },
        error: (error) => console.error('Error loading all videos:', error)
      });
    } else {
      this.filteredVideos = this.featuredVideos.slice(0, 9);
    }
  }

  onVideoClick(video: VideoGetDto): void {
    if (this.currentUser) {
      this.router.navigate(['/video', video.id]);
    } else {
      // Redirect to login for non-logged users
      this.router.navigate(['/login'], { queryParams: { returnUrl: `/video/${video.id}` } });
    }
  }

  onChannelClick(instructorId: number, event: Event): void {
    event.stopPropagation();
    if (this.currentUser) {
      this.router.navigate(['/channel', instructorId]);
    } else {
      this.router.navigate(['/login']);
    }
  }

  formatDuration(duration: string): string {
    // Assuming duration is in format "HH:mm:ss" or "mm:ss"
    return duration;
  }

  formatPrice(price: number): string {
    return price === 0 ? 'Free' : `$${price}`;
  }
}