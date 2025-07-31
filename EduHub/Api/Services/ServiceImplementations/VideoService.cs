
using Application.Mappers;
using Application.Repositories;
using Core.Errors;

namespace Application.Services.ServiceImplementations
{
    public class VideoService(
     IVideoRepository videoRepository,
     ICategoryRepository categoryRepository,
     IChannelRepository instructorRepository
     ) : IVideoService

    {
        public async Task<long> AddVideoAsync(VideoCreateDto dto)
        {
            var category = await categoryRepository.SelectByIdAsync(dto.CategoryId)
                ?? throw new NotFoundException("Category not found");

            var instructor = await instructorRepository.SelectByIdAsync(dto.InstructorId)
                ?? throw new NotFoundException("Instructor not found");

            var video = VideoMapper.ToVideoEntity(dto);
            return await videoRepository.InsertAsync(video);
        }

        public async Task DeleteVideoAsync(long videoId)
        {
            await videoRepository.DeleteAsync(videoId);
        }

        public async Task<VideoGetDto> GetVideoByIdAsync(long videoId)
        {
            var video = await videoRepository.SelectVideoByIdAsync(videoId)
                ?? throw new NotFoundException("video not found");

            return VideoMapper.ToVideoGetDto(video);
        }

        public async Task<IEnumerable<VideoGetDto>> GetAllVideosAsync()
        {
            var videos = await videoRepository.SelectAllVideosAsync();
            return videos.Select(VideoMapper.ToVideoGetDto).ToList();
        }

        public async Task<IEnumerable<VideoGetDto>> GetVideosByInstructorAsync(long instructorId)
        {
            var videos = await videoRepository.SelectVideoByInstructorIdAsync(instructorId);
            return videos.Select(VideoMapper.ToVideoGetDto).ToList();
        }

        public async Task<IEnumerable<VideoGetDto>> GetVideosByCateforyIdAsync(long categoryid)
        {
            var videos = await videoRepository.SelectVideosByCategoryIdAsync(categoryid);
            return videos.Select(VideoMapper.ToVideoGetDto).ToList();
        }

        public async Task UpdateVideoasync(long videoId, VideoUpdateDto dto)
        {
            var existingVideo = await videoRepository.SelectVideoByIdAsync(videoId);

                if (existingVideo is null) throw new NotFoundException($"Video with {videoId} not found");
            else
            {
                existingVideo.Name = dto.Name;
                existingVideo.Description = dto.Description;
                existingVideo.Price = dto.Price;               
            }
        }
    }
}
