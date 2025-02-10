using Microsoft.AspNetCore.Authorization;
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
    public class PokemonStatController(IPokemonDbContext pokemonDbContext) : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllPokemonStats")]
        public async Task<IActionResult> GetAllPokemonStats()
        {
            var stats = await pokemonDbContext.PokemonStats.ToListAsync();
            return Ok(stats);
        }

        [HttpGet("GetPokemonStat")]
        public async Task<IActionResult> GetPokemonStat(int pokemonId)
        {
            var stat = await pokemonDbContext.PokemonStats.FirstOrDefaultAsync((p)=>p.PokemonId == pokemonId);
            //if (stat == null) return BadRequest("No Stat found with the Pokemon Id provided.");
            return Ok(stat);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddPokemonStat")]
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

            await pokemonDbContext.PokemonStats.AddAsync(newStat);
            await pokemonDbContext.SaveChangesAsync();
            return Ok($"Stats for Pokemon with Id {pokemonStatsDto.PokemonId} has been added.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("EditPokemonStat")]
        public async Task<IActionResult> EditPokemonStat(int id, PokemonStatsDto pokemonStatsDto)
        {
            var stat = await pokemonDbContext.PokemonStats.FindAsync(id);
            if (stat == null) return BadRequest("No Stat found with the id provided.");
            
            stat.Hp = pokemonStatsDto.Hp;
            stat.Atk = pokemonStatsDto.Atk;
            stat.Def = pokemonStatsDto.Def;
            stat.Spd = pokemonStatsDto.Spd;
            stat.SAtk = pokemonStatsDto.SAtk;
            stat.SDef = pokemonStatsDto.SDef;

            await pokemonDbContext.SaveChangesAsync();
            return Ok($"Stats for Pokemon with Id {pokemonStatsDto.PokemonId} has been updated");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletePokemonStat")]
        public async Task<IActionResult> DeletePokemonStat(int id)
        {
            var stat = await pokemonDbContext.PokemonStats.FindAsync(id);
            if (stat == null) return BadRequest("No Stat found with the id provided.");
            pokemonDbContext.PokemonStats.Remove(stat);
            await pokemonDbContext.SaveChangesAsync();
            return Ok($"Stats for Pokemon Id {stat.PokemonId} has been deleted.");
        }
    }
}
