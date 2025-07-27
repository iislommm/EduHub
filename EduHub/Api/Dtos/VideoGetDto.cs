public class VideoGetDto
{
    public long VideoId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MB { get; set; }
    public decimal Price { get; set; }
    public int Views { get; set; }
    public string Comments { get; set; } // agar bu string tipida saqlansa
    public string VideoUrl { get; set; }
    public string Category { get; set; } // Category.Name yoki CategoryId emasmi?
    public string Instructor { get; set; } // Instructor.Name yoki FullName bo‘lishi mumkin
}
    