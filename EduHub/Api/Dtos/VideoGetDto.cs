using Domain.Entities;

namespace Application.Dtos;

public class VideoGetDto
{
    public long VideoId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MB { get; set; }
    public int Views { get; set; }
    public string Comments { get; set; }
    public TimeSpan Duration { get; set; }
    public string VideoUrl { get; set; }
    public CategoryDto Category { get; set; }
    public InstructorDto Instructor { get; set; }
}
