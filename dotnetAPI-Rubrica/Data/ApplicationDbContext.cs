using dotnetAPI_footballTeam.Models;
using dotnetAPI_Rubrica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnetAPI_footballTeam.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Team> Teams { get; set; }
       public DbSet<Player> Players { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                .HasOne(t => t.Team)
                .WithOne(u => u.ApplicationUser)
                .HasForeignKey<Team>(k => k.ApplicationUserId);
            builder.Entity<Team>()
                .HasOne(t => t.ApplicationUser)
                .WithOne(u => u.Team)
                .HasForeignKey<ApplicationUser>(u => u.TeamId);
            builder.Entity<Team>().HasData(
                               new Team
                               {
                                   Id = 1,
                                   Name = "Real Madrid",
                                   State = "Spagna",
                                   City = "Madrid",
                                   Stadium = "Santiago Bernabeu",
                                   ApplicationUserId = "70b76440-7470-44ee-a34e-8339ed2c844d"
                               },
                                              new Team
                                              {
                                                  Id = 2,
                                                  Name = "Ac Milan",
                                                  State = "Italia",
                                                  City = "Milano",
                                                  Stadium = "San Siro",
                                                  ApplicationUserId = "eb6fe828-ac5a-4f9e-b7e5-f8e2729f3b8d"
                                              },
                                              new Team
                                              {
                                                  Id = 3,
                                                  Name = "Chelsea",
                                                  State = "Inghilterra",
                                                  City = "Londra",
                                                  Stadium = "Stamford Bridge",
                                                  ApplicationUserId = "fc20aa2e-b2ad-41fa-9f8c-7924445ca387"
                                              }

                                                                        );
            builder.Entity<Player>().HasData(
                               new Player
                               {
                                   Id = 1,
                                   Name = "Karim",
                                   Lastname = "Benzema",
                                   DateOfBirth = new System.DateTime(1987, 12, 19),
                                   Role = "Attaccante",
                                   Value = 50,
                                   ContractExpiration = new System.DateTime(2022, 6, 30),
                                   TeamId = 1,
                               },
                                              new Player
                                              {
                                                  Id = 2,
                                                  Name = "Zlatan",
                                                  Lastname = "Ibrahimovic",
                                                  DateOfBirth = new System.DateTime(1981, 10, 3),
                                                  Role = "Attaccante",
                                                  Value = 5,
                                                  ContractExpiration = new System.DateTime(2021, 6, 30),
                                                  TeamId = 2
                                              },
                                                             new Player
                                                             {
                                                                 Id = 3,
                                                                 Name = "N'Golo",
                                                                 Lastname = "Kante",
                                                                 DateOfBirth = new System.DateTime(1991, 3, 29),
                                                                 Role = "Centrocampista",
                                                                 Value = 100,
                                                                 ContractExpiration = new System.DateTime(2023, 6, 30),
                                                                 TeamId = 3
                                                             },

                                                             new Player
                                                             {
                                                                 Id = 4,
                                                                 Name = "Eden",
                                                                 Lastname = "Hazard",
                                                                 DateOfBirth = new System.DateTime(1991, 1, 7),
                                                                 Role = "Centrocampista",
                                                                 Value = 100,
                                                                 ContractExpiration = new System.DateTime(2024, 6, 30),
                                                                 TeamId = null

                                                             }
                                                                            );








        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
