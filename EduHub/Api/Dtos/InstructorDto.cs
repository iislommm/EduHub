using Domain.Entities;

namespace Application.Dtos;

public class InstructorDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string ProfileImageUrl { get; set; }
    public string SocialLink { get; set; }
    public DateTime RegisteredAt { get; set; }
    public ICollection<VideoDto> Videos { get; set; }
}
