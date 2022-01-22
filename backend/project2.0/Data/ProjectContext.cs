using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project2._0.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project2._0.Data
{
    public class ProjectContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProjectContext(DbContextOptions options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Collab> Collabs { get; set; }
        public DbSet<CollabArtist> CollabArtists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to many
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Albums)
                .WithOne(al => al.Artist);

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album);

            // one to one
            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Manager)
                .WithOne(m => m.Artist);

            // many to many -> 2 one to many
            // intai compunem cheia primara a tabelei de legatura 
            modelBuilder.Entity<CollabArtist>().HasKey(ca => new { ca.ArtistId, ca.CollabId });
            modelBuilder.Entity<CollabArtist>()
                .HasOne(ca => ca.Artist)
                .WithMany(a => a.CollabArtists)
                .HasForeignKey(ca => ca.ArtistId);
            modelBuilder.Entity<CollabArtist>()
                .HasOne(ca => ca.Collab)
                .WithMany(c => c.CollabArtists)
                .HasForeignKey(ca => ca.CollabId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });
        }
    }
}
