using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WonderlandAnimal.Models;

namespace WonderlandAnimal.Controllers
{
    [ApiController]
    public class LocationController:ControllerBase
    {
        [HttpGet("locations/{pointId}")]
        public async Task<IActionResult> Get(long pointId)
        {
            if (pointId == null || pointId <= 0)
            {
                return BadRequest(400);
            }

            LocationPoint point = new LocationPoint();
            point.Id = pointId;
            point.Latitude = 234.4;
            point.Latitude = 45.3342;
            return Ok(point);
        }

        [HttpPost("locations")]
        public async Task<IActionResult> Post(double latitude, double longitude)
        {
            if (latitude == null || latitude < -90 || latitude > 90 || longitude == null || longitude < -180 ||
                longitude > 180)
            {
                return BadRequest(400);
            }

            LocationPoint point = new LocationPoint();
            point.Id = 1;
            point.Latitude = latitude;
            point.Longitude = longitude;
            return Ok(point);
        }
        
        [HttpPut("locations")]
        public async Task<IActionResult> Put(double latitude, double longitude)
        {
            if (latitude == null || latitude < -90 || latitude > 90 || longitude == null || longitude < -180 ||
                longitude > 180)
            {
                return BadRequest(400);
            }

            LocationPoint point = new LocationPoint();
            point.Id = 1;
            point.Latitude = latitude;
            point.Longitude = longitude;
            return Ok(point);
        }
        
        [HttpDelete("locations/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}