using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pokedex.Core.Domain.Common;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Pokemon> pokemons { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Tipo> tipos { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State) 
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "Generico";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Generico";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API

            #region Tables
            modelBuilder.Entity<Pokemon>().ToTable("Pokemons");
            modelBuilder.Entity<Region>().ToTable("Regions");
            modelBuilder.Entity<Tipo>().ToTable("Tipos");
            #endregion

            #region "Primary Keys"
            modelBuilder.Entity<Pokemon>().HasKey(p => p.Id);
            modelBuilder.Entity<Region>().HasKey(r => r.Id);
            modelBuilder.Entity<Tipo>().HasKey(t => t.Id);
            #endregion

            #region Relations
            modelBuilder.Entity<Region>().HasMany<Pokemon>(r => r.Pokemons)
                .WithOne(p => p.region)
                .HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tipo>().HasMany<Pokemon>(t => t.Pokemons)
                .WithOne(p => p.tipo)
                .HasForeignKey(p => p.TypeId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Property Configurations"
            //Pokemon Table Configuration
            #region Pokemon
            modelBuilder.Entity<Pokemon>()
            .Property(p => p.Id)
            .UseIdentityColumn(1,1);
            #endregion

            //Region Table Configuration
            #region Region
            modelBuilder.Entity<Region>()
            .Property(r => r.Id)
            .UseIdentityColumn(1,1);
            #endregion
            //Tipo Table Configuration        
            #region Tipo
            modelBuilder.Entity<Tipo>()
            .Property(t => t.Id)
            .UseIdentityColumn(1,1);
            #endregion

            #endregion
        }
    }
}
