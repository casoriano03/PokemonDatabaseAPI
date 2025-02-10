using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonDatabaseAPI.Data;
using PokemonDatabaseAPI.Interfaces;
using PokemonDatabaseAPI.Model;

namespace PokemonDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonType2Controller(IPokemonDbContext pokemonDbContext) : ControllerBase
    {
        [HttpGet("GetAllPokemonTypes1")]
        public async Task<IActionResult> GetAllPokemonTypes1()
        {
            var pokemonTypes = await pokemonDbContext.PokemonTypes2.ToListAsync();
            return Ok(pokemonTypes);
        }

        [HttpGet("GetPokemonType2")]
        public async Task<IActionResult> GetPokemonType2(int id)
        {
            var pokemonType2 = await pokemonDbContext.PokemonTypes2.FindAsync(id);
            if (pokemonType2 == null) return BadRequest("No type found with the id provided.");
            return Ok(pokemonType2);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddPokemonType2")]
        public async Task<IActionResult> AddPokemonType2(string newType2)
        {
            if (string.IsNullOrEmpty(newType2)) return BadRequest("Type2 name cannot be empty.");
            var newType = new PokemonType2
            {
                TypeName = newType2
            };

            await pokemonDbContext.PokemonTypes2.AddAsync(newType);
            await pokemonDbContext.SaveChangesAsync();
            return Ok($"Type2 {newType} has been successfully added.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("EditPokemonType2")]
        public async Task<IActionResult> EditPokemonType2(int id, string newType2Name)
        {
            var pokemonType2 = await pokemonDbContext.PokemonTypes2.FindAsync(id);
            if (pokemonType2 == null) return BadRequest("No type2 found with the id provided.");
            if (string.IsNullOrEmpty(newType2Name)) return BadRequest("New Type name cannot be empty.");

            pokemonType2.TypeName = newType2Name;
            await pokemonDbContext.SaveChangesAsync();
            return Ok($"Success! Ability with id {id} has changed to {newType2Name}");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletePokemonType2")]
        public async Task<IActionResult> DeletePokemonType2(int id)
        {
            var pokemonType2 = await pokemonDbContext.PokemonTypes2.FindAsync(id);
            if (pokemonType2 == null) return BadRequest("No type2 found with the id provided.");
            pokemonDbContext.PokemonTypes2.Remove(pokemonType2);
            await pokemonDbContext.SaveChangesAsync();
            return Ok($"Pokemon Type2 with id {id} has been deleted");
        }
    }
}
