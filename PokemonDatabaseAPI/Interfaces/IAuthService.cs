using PokemonDatabaseAPI.Model;

namespace PokemonDatabaseAPI.Interfaces;

public interface IAuthService
{
    string CreateToken(User user);
}