export interface CommentCreateDto {
  userId: number;
  videoId: number;
  text: string;
}

export interface CommentDto {
  id: number;
  userId: number;
  username: string;
  videoId: number;
  text: string;
  createdAt: Date;
}