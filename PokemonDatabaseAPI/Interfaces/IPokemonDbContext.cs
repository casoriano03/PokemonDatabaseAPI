using Microsoft.EntityFrameworkCore;
using PokemonDatabaseAPI.Model;

namespace PokemonDatabaseAPI.Interfaces;

public interface IPokemonDbContext
{
    DbSet<Pokemon> Pokemons { get; set; }
    DbSet<PokemonStats> PokemonStats { get; set; }
    DbSet<PokemonType1> PokemonTypes1 { get; set; }
    DbSet<PokemonType2> PokemonTypes2 { get; set; }
    DbSet<PokemonAbility> PokemonAbilities { get; set; }
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}