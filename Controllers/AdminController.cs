using BubbleTeaEF;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace homework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IDbContextFactory<InventoryDbContext> _dbContextFactory;

        public AdminController(IDbContextFactory<InventoryDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        [HttpPut("Ingredients")]
        public async Task<IActionResult> AddIngredient([FromBody] Ingredient ingredient)
        {
            var dbContext = await _dbContextFactory.CreateDbContextAsync();
            dbContext.Ingredients.Add(ingredient);
            await dbContext.SaveChangesAsync();

            return Ok(ingredient.IngredientId);
        }

        [HttpGet("Ingredients")]
        public async Task<IActionResult> GetIngredients()
        {
            var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var ingredients = await dbContext.Ingredients.ToListAsync();
            return Ok(ingredients);
        }

        [HttpPost("CreateDB")]
        public async Task<IActionResult> CreateDB()
        {
            var dbContext = await _dbContextFactory.CreateDbContextAsync();
            await dbContext.Database.EnsureCreatedAsync();
            return Ok();
        }
        
    }
}
