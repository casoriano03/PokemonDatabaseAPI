namespace PokemonDatabaseAPI.Model.Dto
{
    public class UserRegistrationDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHashed { get; set; }
        public required string Role { get; set; }
    }
}
