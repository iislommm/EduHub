export interface LikeCreateDto {
  userId: number;
  videoId: number;
}

export interface LikeDto {
  id: number;
  userId: number;
  videoId: number;
  createdAt: Date;
}