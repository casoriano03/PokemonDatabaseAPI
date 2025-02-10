using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PokemonDatabaseAPI.Interfaces;
using PokemonDatabaseAPI.Model;

namespace PokemonDatabaseAPI.Data
{
    public class PokemonDbContext : DbContext, IPokemonDbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasIndex(p => p.PokedexEntryNumber)
                .IsUnique();
            modelBuilder.Entity<Pokemon>()
                .HasIndex(p => p.PokemonName)
                .IsUnique();
            modelBuilder.Entity<PokemonAbility>()
                .HasIndex(p=>p.AbilityName)
                .IsUnique();
            modelBuilder.Entity<PokemonType1>()
                .HasIndex(p=>p.TypeName)
                .IsUnique();
            modelBuilder.Entity<PokemonType2>()
                .HasIndex(p=>p.TypeName)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PokemonAbility>().HasData(
                new PokemonAbility{ Id = 1, AbilityName = "Overgrow"},
                new PokemonAbility{Id = 2, AbilityName = "Blaze"},
                new PokemonAbility{Id = 3, AbilityName = "Torrent"}
                );

            modelBuilder.Entity<PokemonType1>().HasData(
                new PokemonType1{Id = 1, TypeName = "Normal"},
                new PokemonType1{Id = 2, TypeName = "Fire"},
                new PokemonType1 { Id = 3, TypeName = "Water"},
                new PokemonType1 { Id = 4, TypeName = "Electric"},
                new PokemonType1 { Id = 5, TypeName = "Grass"},
                new PokemonType1 { Id = 6, TypeName = "Ice" },
                new PokemonType1 { Id = 7, TypeName = "Fighting" },
                new PokemonType1 { Id = 8, TypeName = "Poison" },
                new PokemonType1 { Id = 9, TypeName = "Ground" },
                new PokemonType1 { Id = 10, TypeName = "Flying" },
                new PokemonType1 { Id = 11, TypeName = "Psychic" },
                new PokemonType1 { Id = 12, TypeName = "Bug" },
                new PokemonType1 { Id = 13, TypeName = "Rock" },
                new PokemonType1 { Id = 14, TypeName = "Ghost" },
                new PokemonType1 { Id = 15, TypeName = "Dragon" },
                new PokemonType1 { Id = 16, TypeName = "Dark" },
                new PokemonType1 { Id = 17, TypeName = "Steel" },
                new PokemonType1 { Id = 18, TypeName = "Fairy" }
                );

            modelBuilder.Entity<PokemonType2>().HasData(
                new PokemonType2 { Id = 1, TypeName = "Normal" },
                new PokemonType2 { Id = 2, TypeName = "Fire" },
                new PokemonType2 { Id = 3, TypeName = "Water" },
                new PokemonType2 { Id = 4, TypeName = "Electric" },
                new PokemonType2 { Id = 5, TypeName = "Grass" },
                new PokemonType2 { Id = 6, TypeName = "Ice" },
                new PokemonType2 { Id = 7, TypeName = "Fighting" },
                new PokemonType2 { Id = 8, TypeName = "Poison" },
                new PokemonType2 { Id = 9, TypeName = "Ground" },
                new PokemonType2 { Id = 10, TypeName = "Flying" },
                new PokemonType2 { Id = 11, TypeName = "Psychic" },
                new PokemonType2 { Id = 12, TypeName = "Bug" },
                new PokemonType2 { Id = 13, TypeName = "Rock" },
                new PokemonType2 { Id = 14, TypeName = "Ghost" },
                new PokemonType2 { Id = 15, TypeName = "Dragon" },
                new PokemonType2 { Id = 16, TypeName = "Dark" },
                new PokemonType2 { Id = 17, TypeName = "Steel" },
                new PokemonType2 { Id = 18, TypeName = "Fairy" }
            );
        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonStats> PokemonStats { get; set; }
        public DbSet<PokemonType1> PokemonTypes1 { get; set; }
        public DbSet<PokemonType2> PokemonTypes2 { get; set; }
        public DbSet<PokemonAbility> PokemonAbilities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
