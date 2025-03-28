using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Progetto_S19_L5.Models;
using Progetto_S19_L5.Models.Auth;

namespace Progetto_S19_L5.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<
            ApplicationUser,
            ApplicationRole,
            string,
            IdentityUserClaim<string>,
            ApplicationUserRole,
            IdentityUserLogin<string>,
            IdentityRoleClaim<string>,
            IdentityUserToken<string>
        >
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // correlazione UserRole a Role
            modelBuilder
                .Entity<ApplicationUserRole>()
                .HasOne(a => a.ApplicationUser)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(a => a.UserId);

            // correlazione UserRole a User
            modelBuilder
                .Entity<ApplicationUserRole>()
                .HasOne(a => a.ApplicationRole)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(a => a.RoleId);

            // correlazione Ticket a User
            modelBuilder
                .Entity<Ticket>()
                .HasOne(t => t.ApplicationUser)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId);

            // correlazione Ticket a Event
            modelBuilder
                .Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EventId);

            // correlazione Event a Artist
            modelBuilder
                .Entity<Event>()
                .HasOne(e => e.Artist)
                .WithMany(a => a.Events)
                .HasForeignKey(e => e.ArtistId);

            // inserimento ruoli nella tabella ApplicationRoles
            modelBuilder
                .Entity<ApplicationRole>()
                .HasData(
                    new ApplicationRole()
                    {
                        Id = "8d64359a-fda6-4096-b40d-f1375775244d",
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                    },
                    new ApplicationRole()
                    {
                        Id = "849b8726-44b3-434b-9b18-48a4e8d4e9dd",
                        Name = "User",
                        NormalizedName = "User",
                    }
                );

            // Inserisce valori nella tabella ApplicationUser
            modelBuilder
                .Entity<ApplicationUser>()
                .HasData(
                    // password = adminadmin
                    new ApplicationUser()
                    {
                        Id = "55e83e62-2057-45b0-82fe-33a4cba69a2e",
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@example.com",
                        UserName = "admin@example.com",
                        NormalizedUserName = "ADMIN@EXAMPLE.COM",
                        NormalizedEmail = "ADMIN@EXAMPLE.COM",
                        PasswordHash =
                            "AQAAAAIAAYagAAAAEPTjFiaYaGtq8tsslxnhffNqhCeoVvpygVnS8vRbrx/pI2O2Nb7Q75iDvT4ZIQWV4g==",
                        PhoneNumber = "0000000000",
                    },
                    // password = mariomario
                    new ApplicationUser()
                    {
                        Id = "7f11db70-49f5-4c66-bad3-51085c2bd27a",
                        FirstName = "Mario",
                        LastName = "Mario",
                        Email = "mario.mario@examople.com",
                        UserName = "mario.mario@example.com",
                        NormalizedUserName = "MARIO.MARIO@EXAMPLE.COM",
                        NormalizedEmail = "MARIO.MARIO@EXAMPLE.COM",
                        PasswordHash =
                            "AQAAAAIAAYagAAAAEKaVk2PilFpBF+5mhGmCiGOtIF+qHjjpf0Z4ukKkpAnff1/s2WJ/UiFQh4aZ9iP2YQ==",
                        PhoneNumber = "1111111111",
                    },
                    // password = luigimario
                    new ApplicationUser()
                    {
                        Id = "766609fc-a1bd-4ca8-bc3b-8167dd9ba0f2",
                        FirstName = "Luigi",
                        LastName = "Mario",
                        Email = "luigi.mario@example.com",
                        UserName = "luigi.mario@example.com",
                        NormalizedUserName = "LUIGI.MARIO@EXAMPLE.COM",
                        NormalizedEmail = "LUIGI.MARIO@EXAMPLE.COM",
                        PasswordHash =
                            "AQAAAAIAAYagAAAAEHyzjydlPHBKYr6FC7KflthqGK/GbH+NZI8pY+a4rzNrqB7yy7z2HO+fuvlBfxjk5w==",
                        PhoneNumber = "2222222222",
                    }
                );

            // Inserisce valori nella tabella ApplicationUserRoles
            modelBuilder
                .Entity<ApplicationUserRole>()
                .HasData(
                    new ApplicationUserRole()
                    {
                        UserId = "55e83e62-2057-45b0-82fe-33a4cba69a2e",
                        RoleId = "8d64359a-fda6-4096-b40d-f1375775244d",
                    },
                    new ApplicationUserRole()
                    {
                        UserId = "7f11db70-49f5-4c66-bad3-51085c2bd27a",
                        RoleId = "849b8726-44b3-434b-9b18-48a4e8d4e9dd",
                    },
                    new ApplicationUserRole()
                    {
                        UserId = "766609fc-a1bd-4ca8-bc3b-8167dd9ba0f2",
                        RoleId = "849b8726-44b3-434b-9b18-48a4e8d4e9dd",
                    }
                );
        }
    }
}
