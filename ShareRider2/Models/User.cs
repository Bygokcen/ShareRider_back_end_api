using System.ComponentModel.DataAnnotations;

namespace ShareRider2.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    public string FirstName { get; set;}
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set;}
    public byte[] PasswordSalt { get; set; }
    public string Gender { get; set; }
    public bool IsBlocked { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public List<Journey> Journeys { get; set; } = new();
}