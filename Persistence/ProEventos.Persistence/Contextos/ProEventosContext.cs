using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using System;

namespace ProEventos.Persistence.Contextos

{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura a chave primária composta para PalestranteEvento
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            // Define a precisão e a escala para a propriedade Preco na entidade Lote
            modelBuilder.Entity<Lote>()
                .Property(l => l.Preco)
                .HasColumnType("decimal(18,2)"); // Define a precisão (18) e a escala (2)

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedeSociais)
                .WithOne(rs =>rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
             .HasMany(e => e.RedeSociais)
             .WithOne(rs => rs.Palestrante)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
