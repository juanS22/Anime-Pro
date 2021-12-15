using Anime_Pro.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SeriePersonaje>()
                .HasKey(sp => new { sp.PersonajeId, sp.SerieId });
            modelBuilder.Entity<SerieGenero>()
                .HasKey(sg => new { sg.SerieId, sg.GeneroId });
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Estudio> Estudios { get; set; }

        public DbSet<Personaje> Personajes { get; set; }

        public DbSet<Serie> Series { get; set; }
        public DbSet<SeriePersonaje> SeriesPersonajes { get; set; }
        public DbSet<SerieGenero> SeriesGeneros { get; set; }

    }
}
