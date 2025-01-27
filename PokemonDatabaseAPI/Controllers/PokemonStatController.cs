using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonDatabaseAPI.Interfaces;
using PokemonDatabaseAPI.Model;
using PokemonDatabaseAPI.Model.Dto;

namespace PokemonDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonStatController : ControllerBase
    {
        private readonly IPokemonDbContext _pokemonDbContext;

        public PokemonStatController(IPokemonDbContext pokemonDbContext)
        {
            _pokemonDbContext = pokemonDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPokemonStats()
        {
            var stats = await _pokemonDbContext.PokemonStats.ToListAsync();
            return Ok(stats);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPokemonStat(int id)
        {
            var stat = await _pokemonDbContext.PokemonStats.FindAsync(id);
            if (stat == null) return BadRequest("No Stat found with the id provided.");
            return Ok(stat);
        }

        [HttpPost("{PokemonStatsDto}")]
        public async Task<IActionResult> AddPokemonStat(PokemonStatsDto pokemonStatsDto)
        {
            var newStat = new PokemonStats()
            {
                Hp = pokemonStatsDto.Hp,
                Atk = pokemonStatsDto.Atk,
                Def = pokemonStatsDto.Def,
                Spd = pokemonStatsDto.Spd,
                SAtk = pokemonStatsDto.SAtk,
                SDef = pokemonStatsDto.SDef,
                PokemonId = pokemonStatsDto.PokemonId,
            };

            await _pokemonDbContext.PokemonStats.AddAsync(newStat);
            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Stats for Pokemon with Id {pokemonStatsDto.PokemonId} has been added.");
        }

        [HttpPut("{id:int},{PokemonStatsDto}")]
        public async Task<IActionResult> EditPokemonStat(int id, PokemonStatsDto pokemonStatsDto)
        {
            var stat = await _pokemonDbContext.PokemonStats.FindAsync(id);
            if (stat == null) return BadRequest("No Stat found with the id provided.");
            
            stat.Hp = pokemonStatsDto.Hp;
            stat.Atk = pokemonStatsDto.Atk;
            stat.Def = pokemonStatsDto.Def;
            stat.Spd = pokemonStatsDto.Spd;
            stat.SAtk = pokemonStatsDto.SAtk;
            stat.SDef = pokemonStatsDto.SDef;

            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Stats for Pokemon with Id {pokemonStatsDto.PokemonId} has been updated");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePokemonStat(int id)
        {
            var stat = await _pokemonDbContext.PokemonStats.FindAsync(id);
            if (stat == null) return BadRequest("No Stat found with the id provided.");
            _pokemonDbContext.PokemonStats.Remove(stat);
            await _pokemonDbContext.SaveChangesAsync();
            return Ok($"Stats for Pokemon Id {stat.PokemonId} has been deleted.");
        }
    }
}
