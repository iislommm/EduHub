using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos;

public class VideoCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile VideoUrl { get; set; }
    public CategoryDto Category { get; set; }
    
}
