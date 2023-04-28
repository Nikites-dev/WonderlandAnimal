using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WonderlandAnimal.Models;

namespace WonderlandAnimal.Controllers
{
    [ApiController]
    public class AnimalLocationController: ControllerBase
    {
        [HttpGet("animals/{animalId}/locations")]
        private async Task<IActionResult> Get(long animalId, DateTime startDateTime, DateTime endDateTime, int from, int size)
        {
            if (animalId == null && animalId <= 0 && from < 0 && size <= 0 && startDateTime == null && isFormatISO8601(startDateTime) && endDateTime == null && isFormatISO8601(endDateTime))
            {
                return BadRequest(400);
            }
            AnimalVisitedLocation location = new AnimalVisitedLocation();
            location.Id = animalId;
            location.LocationPointId = 23;
            location.DateTimeOfVisitLocationPoint = DateTime.Parse("2010-08-20T15:00:00Z", null,
                System.Globalization.DateTimeStyles.RoundtripKind);
            return Ok(location);
        }
        
        private bool isFormatISO8601(DateTime datetime)
        {
            DateTime result = new DateTime();
            if (DateTime.TryParseExact(datetime.ToString(), "yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out result))
                return true;
            return false;
        }
    }
}