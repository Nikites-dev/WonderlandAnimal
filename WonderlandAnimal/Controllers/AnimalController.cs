using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WonderlandAnimal.Models;

namespace WonderlandAnimal.Controllers
{
    [ApiController]
    public class AnimalController:ControllerBase
    {
        [HttpGet("animals/{animalId}")]
        public async Task<IActionResult> Get(long? animalId)
        {
            if (animalId is > 0)
            {
                Animal animal = new Animal();
                animal.Id = animalId.Value;
                animal.AnimalTypes = new long[10];
                animal.Weight = 1000;
                animal.Length = 220;
                animal.Height = 100;
                animal.Gender = "MALE";
                animal.LifeStatus = "ALIVE";
                animal.ChippingDateTime = DateTime.Parse("2010-08-20T15:00:00Z", null,
                    System.Globalization.DateTimeStyles.RoundtripKind);
                animal.ChipperId = 1;
                animal.ChippingLocationId = 10;
                animal.VisitedLocations = new long[5];
                animal.DeathDateTime = null;
                return Ok(animal);
                
            }
            return BadRequest(400);
        }

        [HttpGet("animals/search")]
        public async Task<IActionResult> Get(DateTime dateTime, DateTime startDateTime, DateTime endDateTime,
            int chipperId, long chippingLocationId, String lifeStatus, String gender, int from, int size)
        {

            if (dateTime != null & startDateTime != null & endDateTime != null & chipperId != null & chippingLocationId != null & (lifeStatus != null || lifeStatus != "") & (gender != null || gender != "") & from != null || size != null)
            {
                if (from >= 0 & size > 0 & isFormatISO8601(startDateTime) & isFormatISO8601(startDateTime) &
                    chipperId > 0 & chippingLocationId > 0 & (lifeStatus == "ALIVE" || lifeStatus == "DEAD") &
                    (gender == "MALE" || gender == "FEMALE" || gender == "OTHER"))
                {
                    Animal animal = new Animal();
                    animal.Id = 1;
                    animal.AnimalTypes = new long[10];
                    animal.Weight = 1000;
                    animal.Length = 220;
                    animal.Height = 100;
                    animal.Gender = "MALE";
                    animal.LifeStatus = "ALIVE";
                    animal.ChippingDateTime = DateTime.Parse("2010-08-20T15:00:00Z", null,
                        System.Globalization.DateTimeStyles.RoundtripKind);
                    animal.ChipperId = 1;
                    animal.ChippingLocationId = 10;
                    animal.VisitedLocations = new long[5];
                    animal.DeathDateTime = null;
                    return Ok(animal);
                }

                return BadRequest(400);
            }

            return BadRequest(401);
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