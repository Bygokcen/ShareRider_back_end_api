namespace ShareRider2.Dtos;

public class AddJourneyDto
{
    public int CreatorUserId { get; set; }
    public int DepartureCityId { get; set; }
    public int ArrivalCityId { get; set; }

    public string Description { get; set; } 

    public DateTime JourneyDate { get; set; }
    public int Coast { get; set; }
    public int PassengerCapacity { get; set; } 
}