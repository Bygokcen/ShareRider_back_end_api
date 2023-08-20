using System.ComponentModel.DataAnnotations;

namespace ShareRider2.Models;

public class ShareRider
{
    
    [Key]
    public int ShareRiderId { get; set; }
    public Guid JourneyId { get; set; }
    public int UserId { get; set; }
    
    
}