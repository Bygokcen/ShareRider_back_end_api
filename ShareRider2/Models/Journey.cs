namespace ShareRider2.Models;

public class Journey
{
    public Guid JourneyId { get; set; }
    public int CreatorUserId { get; set; }
    public int DepartureCityId { get; set; }
    public int ArrivalCityId { get; set; }
    
    public string Description { get; set; }
    public DateTime JourneyDate { get; set; }
    public int Coast { get; set; }
    public int PassengerCapacity { get; set; }
    
    public ShareRider ShareRider { get; set; }
    public City DepartureCity { get; set; }
    public City ArrivalCity { get; set; }
    
    public User CreatorUser { get; set; }
    
}