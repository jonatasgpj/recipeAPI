using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recipeAPI.Dto.Ingredient;
using recipeAPI.Dto.Recipe;
using recipeAPI.Models;
using recipeAPI.Services.Ingredient;
using recipeAPI.Services.Recipe;

namespace recipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {

        public HealthController()
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetHealth()
        {
            await Task.CompletedTask;
            return Ok("Response - OK");
        }

    }
}
