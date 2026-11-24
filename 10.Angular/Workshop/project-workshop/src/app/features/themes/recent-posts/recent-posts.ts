import { Component } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { ApiService } from '../../../core/services/api.service';
import { Post } from '../../../../shared/interfaces/post';
import { PostItem } from '../../../../shared/components/post-item/post-item';

@Component({
  selector: 'app-recent-posts',
  imports: [AsyncPipe, PostItem],
  templateUrl: './recent-posts.html',
  styleUrl: './recent-posts.css',
})
export class RecentPosts {
  posts$: Observable<Post[]>;

  constructor(private apiService: ApiService) {
    this.posts$ = this.apiService.getLatestPosts();
  }
}
