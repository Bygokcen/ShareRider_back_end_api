namespace ShareRider2.Dtos;

public class JourneyForListDto
{
    public Guid JourneyId { get; set; }
    public string DepartureCityName { get; set; }
    public string ArrivalCityName { get; set; }
    public string Description { get; set; }
    public DateTime JourneyDate { get; set; }
    public int Coast { get; set; }
    public int PassengerCapacity { get; set; }
    public string CreatorUserName { get; set; }
}