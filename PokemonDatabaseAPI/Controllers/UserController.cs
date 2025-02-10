using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonDatabaseAPI.Interfaces;

namespace PokemonDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IPokemonDbContext pokemonDbContext) : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = pokemonDbContext.Users.ToString();
            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await pokemonDbContext.Users.FindAsync(id);
            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("ChangeRole")]
        public async Task<IActionResult> ChangeRole(int id, string newRole)
        {
            var user = await pokemonDbContext.Users.FindAsync(id);
            if (user == null) return BadRequest("No user found with the id provided.");
            if (string.IsNullOrEmpty(newRole)) return BadRequest("New role cannot be empty.");
            user.Role = newRole;
            await pokemonDbContext.SaveChangesAsync();
            return Ok($"Success! User with id {id} has changed to {newRole} role");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await pokemonDbContext.Users.FindAsync(id);
            if (user == null) return BadRequest("No user found with the id provided.");
            pokemonDbContext.Users.Remove(user);
            await pokemonDbContext.SaveChangesAsync();
            return Ok($"User with id {id} has been successfully deleted.");
        }
    }
}
