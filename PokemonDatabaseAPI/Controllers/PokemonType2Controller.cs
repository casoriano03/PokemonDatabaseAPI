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
    public class PokemonType2Controller : ControllerBase
    {
        private readonly IPokemonDbContext _pokemonDbContext;

        public PokemonType2Controller(IPokemonDbContext pokemonDbContext)
        {
            _pokemonDbContext = pokemonDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPokemonTypes1()
        {
            var pokemonTypes = await _pokemonDbContext.PokemonTypes2.ToListAsync();
            return Ok(pokemonTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPokemonType2(int id)
        {
            var pokemonType2 = await _pokemonDbContext.PokemonTypes2.FindAsync(id);
            if (pokemonType2 == null) return BadRequest("No type found with the id provided.");
            return Ok(pokemonType2);
        }

        [HttpPost("{newType2}")]
        public async Task<IActionResult> AddPokemonType2(string newType2)
        {
            if (string.IsNullOrEmpty(newType2)) return BadRequest("Type2 name cannot be empty.");
            var newType = new PokemonType2
            {
                TypeName = newType2
            };

            await _pokemonDbContext.PokemonTypes2.AddAsync(newType);
            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Type2 {newType} has been successfully added.");
        }

        [HttpPut("{id:int}/{newType2Name}")]
        public async Task<IActionResult> EditPokemonType2(int id, string newType2Name)
        {
            var pokemonType2 = await _pokemonDbContext.PokemonTypes2.FindAsync(id);
            if (pokemonType2 == null) return BadRequest("No type2 found with the id provided.");
            if (string.IsNullOrEmpty(newType2Name)) return BadRequest("New Type name cannot be empty.");

            pokemonType2.TypeName = newType2Name;
            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Success! Ability with id {id} has changed to {newType2Name}");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePokemonType2(int id)
        {
            var pokemonType2 = await _pokemonDbContext.PokemonTypes2.FindAsync(id);
            if (pokemonType2 == null) return BadRequest("No type2 found with the id provided.");
            _pokemonDbContext.PokemonTypes2.Remove(pokemonType2);
            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Pokemon Type2 with id {id} has been deleted");
        }
    }
}
