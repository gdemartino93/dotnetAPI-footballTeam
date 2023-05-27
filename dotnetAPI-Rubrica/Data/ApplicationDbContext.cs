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
            //create teams
            builder.Entity<Team>().HasData(
                               new Team
                               {
                    Id = new System.Guid("8f8389e8-ca42-4d01-86c4-6ec014c329db"),
                    Name = "Real Madrid",
                    State = "Spagna",
                    City = "Madrid",
                    Stadium = "Santiago Bernabeu"
                },
                                              new Team
                                              {
                    Id = new System.Guid("da2a6671-e64b-416b-a8fb-95cd78e3dc45"),
                    Name = "Ac Milan",
                    State = "Italia",
                    City = "Milano",
                    Stadium = "San Siro"
                },
                                                             new Team
                                                             {
                    Id = new System.Guid("f0d21b25-b57d-4968-abb6-a1dbba5fea9a"),
                    Name = "Chelsea",
                    State = "Inghilterra",
                    City = "London",
                    Stadium = "Stamford Bridge"
                }
                                                                        );
            //create player for these teams
            builder.Entity<Player>().HasData(
                               new Player
                               {
                    Id = Guid.NewGuid(),
                    Name = "Karim",
                    Lastname = "Benzema",
                    DateOfBirth = new System.DateTime(1987, 12, 19),
                    Role = "Attaccante",
                    Value = 50,
                    ContractExpiration = new System.DateTime(2022, 6, 30),
                    TeamId = "8f8389e8-ca42-4d01-86c4-6ec014c329db"
                },
                                              new Player
                                              {
                    Id = Guid.NewGuid(),
                    Name = "Zlatan",
                    Lastname = "Ibrahimovic",
                    DateOfBirth = new System.DateTime(1981, 10, 3),
                    Role = "Attaccante",
                    Value = 5,
                    ContractExpiration = new System.DateTime(2021, 6, 30),
                    TeamId = "da2a6671-e64b-416b-a8fb-95cd78e3dc45"
                },
                                                             new Player
                                                             {
                    Id = Guid.NewGuid(),
                    Name = "N'Golo",
                    Lastname = "Kante",
                    DateOfBirth = new System.DateTime(1991, 3, 29),
                    Role = "Centrocampista",
                    Value = 100,
                    ContractExpiration = new System.DateTime(2023, 6, 30),
                    TeamId = "f0d21b25-b57d-4968-abb6-a1dbba5fea9a"
                },

                                                             new Player
                                                             {
                                                                 Id = Guid.NewGuid(),
                                                                 Name = "Eden",
                                                                 Lastname = "Hazard",
                                                                 DateOfBirth = new System.DateTime(1991, 1, 7),
                                                                 Role = "Centrocampista",
                                                                 Value = 100,
                                                                 ContractExpiration = new System.DateTime(2024, 6, 30),

                                                             }
                                                                            );


            




        }
    }
}
