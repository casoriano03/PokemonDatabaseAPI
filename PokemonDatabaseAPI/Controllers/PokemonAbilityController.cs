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
    public class PokemonAbilityController : ControllerBase
    {
        private readonly IPokemonDbContext _pokemonDbContext;

        public PokemonAbilityController(IPokemonDbContext pokemonDbContext)
        {
            _pokemonDbContext = pokemonDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPokemonAbilities()
        {
            var pokemonAblities = await _pokemonDbContext.PokemonAbilities.ToListAsync();
            return Ok(pokemonAblities);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPokemonAbility(int id)
        {
            var pokemonAbility = await _pokemonDbContext.PokemonAbilities.FindAsync(id);
            if (pokemonAbility == null) return BadRequest("No ability found with the id provided.");
                

            return Ok(pokemonAbility);
        }

        [HttpPost("{abilityName}")]
        public async Task<IActionResult> AddPokemonAbility(string abilityName)
        {
            if (string.IsNullOrEmpty(abilityName)) return BadRequest("Ability name cannot be empty.");
            
            var newAbility = new PokemonAbility
            {
                AbilityName = abilityName
            };

            await _pokemonDbContext.PokemonAbilities.AddAsync(newAbility);
            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Ability {abilityName} has been successfully added.");
        }

        [HttpPut("{id:int}/{newAbilityName}")]
        public async Task<IActionResult> EditPokemonAbility(int id, string newAbilityName)
        {
            var pokemonAbility = await _pokemonDbContext.PokemonAbilities.FindAsync(id);
            if (pokemonAbility == null) return BadRequest("No ability found with the id provided.");
            if (string.IsNullOrEmpty(newAbilityName)) return BadRequest("New Ability name cannot be empty.");

            pokemonAbility.AbilityName = newAbilityName;
            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Success! Ability with id {id} has changed to {newAbilityName}");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePokemonAbility(int id)
        {
            var pokemonAbility = await _pokemonDbContext.PokemonAbilities.FindAsync(id);
            if (pokemonAbility == null) return BadRequest("No ability found with the id provided.");
            _pokemonDbContext.PokemonAbilities.Remove(pokemonAbility);
            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Pokemon Ability with id {id} has been deleted");
        }
    }
}
