using Domain.Entities;

public class Instructor
{
     public long InstructorId { get; set; }                          
     public string FullName { get; set; }                 
     public string Email { get; set; }                    
     public string Bio { get; set; }                      
     public string ProfileImageUrl { get; set; }          
     public string SocialLink { get; set; }               
     public DateTime RegisteredAt { get; set; }           
     public ICollection<Video> Videos { get; set; }
    public long UserId { get; set; }  

}
