export interface CategoryCreateDto {
  name: string;
}

export interface CategoryDto {
  id: number;
  name: string;
  createdAt: Date;
  videosCount?: number;
}

export interface CategoryUpdateDto {
  name: string;
}