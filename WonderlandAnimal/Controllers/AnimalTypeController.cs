using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WonderlandAnimal.Models;

namespace WonderlandAnimal.Controllers
{
    [ApiController]
    public class AnimalTypeController:ControllerBase
    {
        [HttpGet("animals/types/{typeId}")]
        public async Task<IActionResult> Get(long typeId)
        {
            if (typeId == null || typeId <= 0)
            {
                return BadRequest(400);
            }
            AnimalType animalType = new AnimalType();
            animalType.Id = typeId;
            animalType.Type = "Predator";
            return Ok(animalType);
        }
    }
}