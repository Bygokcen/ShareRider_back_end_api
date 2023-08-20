using Microsoft.EntityFrameworkCore;
using ShareRider2.Models;

namespace ShareRider2.Data;

public class AppRepository:IAppRepository
{
    private readonly DataContext _context;

    public AppRepository(DataContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }

    public bool SaveAll()
    {
        return _context.SaveChanges() > 0;
    }

    

    public Journey GetJourneyById(Guid journeyId)
    {
        var journeys = _context.Journeys.FirstOrDefault(j => j.JourneyId.Equals(journeyId));
        return journeys;
    }

    public List<Journey> GetAllJourneys()
    {
        var journeys = _context.Journeys
            .Include(j => j.DepartureCity)
            .Include(j => j.ArrivalCity)
            .Include(j => j.CreatorUser)
            
            .Select(j => new Journey
            {
                JourneyId = j.JourneyId,
                DepartureCity = j.DepartureCity,
                ArrivalCity = j.ArrivalCity,
                Description = j.Description,
                JourneyDate = j.JourneyDate,
                Coast = j.Coast,
                PassengerCapacity = j.PassengerCapacity,
                CreatorUser = new User
                {
                    FirstName = j.CreatorUser.FirstName,
                    LastName = j.CreatorUser.LastName
                }
            })
            .ToList();

        return journeys;
    }

    public List<City> GetCities()
    {
        return _context.Cities.ToList();
    }

    public List<Journey> GetJourneysByUserId(int userId)
    {
        var joinedJourneyIds = _context.ShareRiders
            .Where(sr => sr.UserId == userId)
            .Select(sr => sr.JourneyId).ToList();

        var journeys = _context.Journeys
            .Where(j => joinedJourneyIds.Contains(j.JourneyId))
            .Select(j=> new Journey
                {
                    DepartureCity = j.DepartureCity,
                    ArrivalCity = j.ArrivalCity,
                    Coast = j.Coast
                }).ToList();
        
        return journeys;
    }
}