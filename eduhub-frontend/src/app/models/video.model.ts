export interface VideoCreateDto {
  name: string;
  description: string;
  mb: number;
  price: number;
  views: number;
  duration: string; // TimeSpan as string
  videoUrl: string;
  categoryId: number;
  instructorId: number;
}

export interface VideoGetDto {
  id: number;
  name: string;
  description: string;
  mb: number;
  price: number;
  views: number;
  duration: string;
  videoUrl: string;
  categoryId: number;
  categoryName: string;
  instructorId: number;
  instructorName: string;
  createdAt: Date;
}

export interface VideoUpdateDto {
  name: string;
  description: string;
  price: number;
}