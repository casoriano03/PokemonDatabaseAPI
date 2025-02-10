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
    public class PokemonAbilityController(IPokemonDbContext pokemonDbContext) : ControllerBase
    {
        [HttpGet("GetAllPokemonAbilities")]
        public async Task<IActionResult> GetAllPokemonAbilities()
        {
            var pokemonAbilities = await pokemonDbContext.PokemonAbilities.ToListAsync();
            return Ok(pokemonAbilities);
        }

        [HttpGet("GetPokemonAbility")]
        public async Task<IActionResult> GetPokemonAbility(int id)
        {
            var pokemonAbility = await pokemonDbContext.PokemonAbilities.FindAsync(id);
            if (pokemonAbility == null) return BadRequest("No ability found with the id provided.");
                

            return Ok(pokemonAbility);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddPokemonAbility")]
        public async Task<IActionResult> AddPokemonAbility(string abilityName)
        {
            if (string.IsNullOrEmpty(abilityName)) return BadRequest("Ability name cannot be empty.");
            
            var newAbility = new PokemonAbility
            {
                AbilityName = abilityName
            };

            await pokemonDbContext.PokemonAbilities.AddAsync(newAbility);
            await pokemonDbContext.SaveChangesAsync();
            return Ok($"Ability {abilityName} has been successfully added.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("EditPokemonAbility")]
        public async Task<IActionResult> EditPokemonAbility(int id, string newAbilityName)
        {
            var pokemonAbility = await pokemonDbContext.PokemonAbilities.FindAsync(id);
            if (pokemonAbility == null) return BadRequest("No ability found with the id provided.");
            if (string.IsNullOrEmpty(newAbilityName)) return BadRequest("New Ability name cannot be empty.");

            pokemonAbility.AbilityName = newAbilityName;
            await pokemonDbContext.SaveChangesAsync();
            return Ok($"Success! Ability with id {id} has changed to {newAbilityName}");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletePokemonAbility")]
        public async Task<IActionResult> DeletePokemonAbility(int id)
        {
            var pokemonAbility = await pokemonDbContext.PokemonAbilities.FindAsync(id);
            if (pokemonAbility == null) return BadRequest("No ability found with the id provided.");
            pokemonDbContext.PokemonAbilities.Remove(pokemonAbility);
            await pokemonDbContext.SaveChangesAsync();
            return Ok($"Pokemon Ability with id {id} has been deleted");
        }
    }
}
