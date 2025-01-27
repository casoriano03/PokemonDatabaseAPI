using System.ComponentModel.DataAnnotations;

namespace PokemonDatabaseAPI.Model.Dto
{
    public class PokemonStatsDto
    {
        [Range(1, 800, ErrorMessage = "Hp must be between 1 and 800.")]
        public required int Hp { get; set; }
        [Range(1, 800, ErrorMessage = "Atk must be between 1 and 800.")]
        public required int Atk { get; set; }
        [Range(1, 800, ErrorMessage = "Def must be between 1 and 800.")]
        public required int Def { get; set; }
        [Range(1, 800, ErrorMessage = "Spd must be between 1 and 800.")]
        public required int Spd { get; set; }
        [Range(1, 800, ErrorMessage = "SAtk must be between 1 and 800.")]
        public required int SAtk { get; set; }
        [Range(1, 800, ErrorMessage = "SDef must be between 1 and 800.")]
        public required int SDef { get; set; }
        [Range(1, 800, ErrorMessage = "Pokemon Id must be between 1 and 800.")]
        public int PokemonId { get; set; }
    }
}
