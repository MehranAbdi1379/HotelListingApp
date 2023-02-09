using HotelListingApp.iRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = _unitOfWork.Countries.GetAll();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex , $"Someting Went Wrong in the {nameof(GetCountries)}");
                return StatusCode(500 , "Internal Server Error. Please Try Again Later.");
            }
        }
    }
}
