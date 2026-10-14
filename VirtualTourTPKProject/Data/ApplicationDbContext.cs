
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualTourTPKProject.Models;

namespace VirtualTourTPKProject.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Building> Buildings => Set<Building>();

        public DbSet<Floor> Floors => Set<Floor>();

        public DbSet<Room> Rooms => Set<Room>();

        public DbSet<Teacher> Teachers => Set<Teacher>();

        public DbSet<Panorama> Panoramas => Set<Panorama>();

        public DbSet<PanoramaTransition> PanoramaTransitions
            => Set<PanoramaTransition>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Building>()
                .ToTable("buildings");

            builder.Entity<Floor>()
                .ToTable("floors");

            builder.Entity<Room>()
                .ToTable("rooms");

            builder.Entity<Teacher>()
                .ToTable("teachers");

            builder.Entity<Panorama>()
                .ToTable("panoramas");

            builder.Entity<PanoramaTransition>()
                .ToTable("panorama_transitions");

            builder.Entity<Floor>()
                .HasIndex(f => new { f.BuildingId, f.FloorNumber })
                .IsUnique();

            builder.Entity<PanoramaTransition>()
                .HasIndex(t => new
                {
                    t.FromPanoramaId,
                    t.ToPanoramaId
                })
                .IsUnique();

            builder.Entity<PanoramaTransition>()
                .HasOne(t => t.FromPanorama)
                .WithMany(p => p.TransitionsFrom)
                .HasForeignKey(t => t.FromPanoramaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PanoramaTransition>()
                .HasOne(t => t.ToPanorama)
                .WithMany(p => p.TransitionsTo)
                .HasForeignKey(t => t.ToPanoramaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Teacher>()
                .HasOne(t => t.OfficeRoom)
                .WithMany(r => r.Teachers)
                .HasForeignKey(t => t.OfficeRoomId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}