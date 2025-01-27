using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonDatabaseAPI.Data;
using PokemonDatabaseAPI.Interfaces;
using PokemonDatabaseAPI.Model;
using PokemonDatabaseAPI.Model.Dto;

namespace PokemonDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonDbContext _pokemonDbContext;

        public PokemonController(IPokemonDbContext pokemonDbContext)
        {
            _pokemonDbContext = pokemonDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPokemons()
        {
            return Ok(await _pokemonDbContext.Pokemons
                .Include(p=>p.PokemonStats)
                .Include(p => p.PokemonAbility)
                .Include(p=> p.PokemonType1)
                .Include(p=> p.PokemonType2)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPokemon(int id)
        {
            var pokemon = await _pokemonDbContext.Pokemons
                .Include(p=>p.PokemonStats)
                .Include(p=> p.PokemonAbility)
                .Include(p=>p.PokemonType1)
                .Include(p=>p.PokemonType2)
                .FirstOrDefaultAsync(p=>p.Id == id);
            if (pokemon == null) return BadRequest("No ability found with the id provided.");

            return Ok(pokemon);
        }

        [HttpPost("{addPokemonDto}")]
        public async Task<IActionResult> AddPokemon(PokemonDto addPokemonDto)
        {
            var newPokemon = new Pokemon
            {
                PokedexEntryNumber = addPokemonDto.PokedexEntryNumber,
                PokemonName = addPokemonDto.PokemonName,
                PokemonDescription = addPokemonDto.PokemonDescription,
                PokemonImgLink = addPokemonDto.PokemonImgLink,
                PokemonAbilityId = addPokemonDto.PokemonAbilityId,
                PokemonType1Id = addPokemonDto.PokemonType1Id,
                PokemonType2Id = addPokemonDto.PokemonType2Id
            };

            await _pokemonDbContext.Pokemons.AddAsync(newPokemon);
            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"New pokemon {addPokemonDto.PokemonName} has added successfully.");
        }

        [HttpPut("{id:int}/{editPokemonDto}")]
        public async Task<IActionResult> EditPokemon(int id, PokemonDto editPokemonDto)
        {
            var pokemon = await _pokemonDbContext.Pokemons.FindAsync(id);
            if (pokemon == null) return BadRequest("No pokemon found with the id provided.");

            pokemon.PokedexEntryNumber = editPokemonDto.PokedexEntryNumber;
            pokemon.PokemonName = editPokemonDto.PokemonName;
            pokemon.PokemonDescription = editPokemonDto.PokemonDescription;
            pokemon.PokemonImgLink = editPokemonDto.PokemonImgLink;
            pokemon.PokemonAbilityId = editPokemonDto.PokemonAbilityId;
            pokemon.PokemonType1Id = editPokemonDto.PokemonType1Id;
            pokemon.PokemonType2Id = editPokemonDto.PokemonType2Id;

            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Pokemon with id number {id} has been updated.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var pokemon = await _pokemonDbContext.Pokemons.FindAsync(id);
            if (pokemon == null) return BadRequest("No pokemon found with the id provided.");

            _pokemonDbContext.Pokemons.Remove(pokemon);
            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Pokemon with id {id} has been deleted.");
        }
    }
}
