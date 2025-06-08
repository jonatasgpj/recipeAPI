using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetHealth()
        {
            _logger.LogInformation("Health check endpoint foi chamado em {Time}", DateTime.UtcNow);
            await Task.CompletedTask;
            return Ok("Response - OK");
        }
    }
}
