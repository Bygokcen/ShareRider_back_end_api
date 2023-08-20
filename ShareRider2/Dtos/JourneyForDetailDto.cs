using ShareRider2.Models;

namespace ShareRider2.Dtos;

public class JourneyForDetailDto
{
    public JourneyForDetailDto(List<User> users)
    {
        Users = users;
    }

    public Guid JourneyId { get; set; }
    public string? Description { get; set; }
    public int DepartureCityId { get; set; }
    public int ArrivalCityId { get; set; }
    public int PassengerCapacity { get; set; }
    public DateTime JourneyDate { get; set; }
    public int Coast { get; set; }
    public int CreatorUserId { get; set; }
    
    public List<User> Users  { get; set; }
}