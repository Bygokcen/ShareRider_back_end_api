using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShareRider2.Data;
using ShareRider2.Dtos;

namespace ShareRider2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneysController : Controller
    {
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public JourneysController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetJourneys()
        {
            var journeys = _appRepository.GetAllJourneys();
            var journeysToReturn = _mapper.Map<List<JourneyForListDto>>(journeys).ToList();
            return Ok(journeysToReturn);
        }

        [HttpGet("api/cities")]
        public IActionResult GetCities()
        {
            var cities = _appRepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityDto>>(cities).ToList();
            return Ok(citiesToReturn);
        }

        [HttpGet("UserJourneys")]
        public IActionResult GetUserJourneysByUserId(int userId)
        {
            var user = _appRepository.GetJourneysByUserId(userId);
            var userToReturn = _mapper.Map<List<JourneyForDetailDto>>(user).ToList();
            return Ok(userToReturn);
        }
            
    }
}
