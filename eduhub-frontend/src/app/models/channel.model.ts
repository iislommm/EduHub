export interface ChannelCreateDto {
  channelName: string;
  bio: string;
  channelImageUrl: string;
  channelLink: string;
}

export interface ChannelDto {
  id: number;
  channelName: string;
  bio: string;
  channelImageUrl: string;
  channelLink: string;
  userId: number;
  username: string;
  createdAt: Date;
  videosCount?: number;
}

export interface ChannelUpdateDto {
  channelName: string;
  bio: string;
  channelImageUrl: string;
  channelLink: string;
}