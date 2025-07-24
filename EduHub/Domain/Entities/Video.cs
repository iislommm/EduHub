namespace Domain.Entities;

public class Video
{
    public long VideoId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MB { get; set; }
    public int Views { get; set; }
    public string Comments { get; set; }
    public TimeSpan Duration { get; set; }
    public string VideoUrl { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; }
}