using Application.Dtos;

namespace Application.Mappers;

public static class InstructorMapper
{
    public static Instructor ToEntity(InstructorCreateDto dto)
    {
        return new Instructor
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Bio = dto.Bio,
            ProfileImageUrl = dto.ProfileImageUrl,
            SocialLink = dto.SocialLink,
            RegisteredAt = DateTime.UtcNow,
        };
    }

    public static InstructorDto ToDto(Instructor instructor)
    {
        return new InstructorDto
        {
            Id = instructor.InstructorId,
            FullName = instructor.FullName,
            Email = instructor.Email,
            Bio = instructor.Bio,
            ProfileImageUrl = instructor.ProfileImageUrl,
            SocialLink = instructor.SocialLink,
            RegisteredAt = instructor.RegisteredAt,             
        };
    }

    public static void UpdateEntity(Instructor instructor, InstructorUpdateDto dto)
    {
        instructor.FullName = dto.FullName;
        instructor.Bio = dto.Bio;
        instructor.ProfileImageUrl = dto.ProfileImageUrl;
        instructor.SocialLink = dto.SocialLink;
    }
}
