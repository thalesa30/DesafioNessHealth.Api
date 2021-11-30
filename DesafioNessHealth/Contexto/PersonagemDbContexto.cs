using DesafioNessHealth.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DesafioNessHealth.Contexto
{
    public class PersonagemDbContexto : DbContext
    {
        public PersonagemDbContexto(DbContextOptions<PersonagemDbContexto> options)
            : base(options) { }
        public DbSet<Personagem> Personagens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Personagem>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("View_Personagens");
                        eb.Property(v => v.Nome).HasColumnName("Nome");
                    });
        }

    }
}
