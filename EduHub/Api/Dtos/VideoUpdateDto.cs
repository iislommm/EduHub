public class VideoUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int MB { get; set; }
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }
    public string VideoUrl { get; set; }
}