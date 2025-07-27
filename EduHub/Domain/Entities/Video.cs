using System.Reflection.Metadata.Ecma335;

namespace Domain.Entities;

public class Video
{
    public long VideoId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MB { get; set; }
    public decimal Price { get; set; }
    public int Views { get; set; }
    public TimeSpan Duration { get; set; }
    public string VideoUrl { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public long InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    public long LikeId { get; set; }
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public long CommentId { get; set; }
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}