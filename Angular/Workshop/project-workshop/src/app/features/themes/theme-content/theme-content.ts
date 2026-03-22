import { Component, inject, OnInit, ChangeDetectorRef, computed } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';
import { ApiService } from '../../../core/services/api.service';
import { Theme } from '../../../../shared/interfaces/theme';
import { Post } from '../../../../shared/interfaces/post';
import { forkJoin, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-theme-content',
  imports: [FormsModule],
  templateUrl: './theme-content.html',
  styleUrl: './theme-content.css',
})
export class ThemeContent implements OnInit {
  private route = inject(ActivatedRoute);
  private apiService = inject(ApiService);
  private cdr = inject(ChangeDetectorRef);
  private authService = inject(AuthService);

  theme: Theme | null = null;
  posts: Post[] = [];
  commentText = '';
  themeId = '';

  currentUsername = computed(() => this.authService.currentUser()?.username ?? 'Anounymous')

  ngOnInit(): void {
    this.themeId = this.route.snapshot.paramMap.get('themeId') ?? '';
    this.loadThemeData();
  }

  loadThemeData(): void {
    forkJoin({
      themes: this.apiService.getThemes().pipe(catchError(() => of([]))),
      posts: this.apiService.getLatestPosts().pipe(catchError(() => of([]))),
    }).subscribe(({ themes, posts }) => {
      this.theme = (themes ?? []).find((t) => t._id === this.themeId) ?? null;
      this.posts = (posts ?? []).filter((p: Post) => p.themeId?._id === this.themeId);
      this.cdr.markForCheck();
    });
  }

  onPostComment(): void {
    console.log('Posting comment', this.commentText);
    this.commentText = '';
  }
}
