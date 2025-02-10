namespace PokemonDatabaseAPI.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHashed { get; set; }
        public string Role { get; set; }
    }
}
