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
                                   Id=1,
                    Name = "Real Madrid",
                    State = "Spagna",
                    City = "Madrid",
                    Stadium = "Santiago Bernabeu"
                },
                                              new Team
                                              {
                                                  Id=2,
                    Name = "Ac Milan",
                    State = "Italia",
                    City = "Milano",
                    Stadium = "San Siro"
                },
                                                             new Team
                                                             {
                                                                 Id=3,
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
                                                                            ); ;


            




        }
    }
}
