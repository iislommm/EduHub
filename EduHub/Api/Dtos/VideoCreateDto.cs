public class VideoCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int MB { get; set; }
    public decimal Price { get; set; }
    public int Views { get; set; }
    public TimeSpan Duration { get; set; }
    public string VideoUrl { get; set; }
    public long CategoryId { get; set; }
    public long InstructorId { get; set; }
}
