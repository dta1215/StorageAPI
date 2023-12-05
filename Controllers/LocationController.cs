using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StorageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetLocation()
        {
            var locations = new string[]
            {
                "Locate 1", "Locate 2" 
            };

            return Ok(locations);
        }
    }
}
