using ShareRider2.Models;

namespace ShareRider2.Data;

public interface IAppRepository
{
    void Add<T>(T entity) where T :class;
    void Delete<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    bool SaveAll();

    
    
    Journey GetJourneyById(Guid journeyId);

    List<Journey> GetAllJourneys();

    List<City> GetCities();
    
    List<Journey>GetJourneysByUserId(int userId);

}