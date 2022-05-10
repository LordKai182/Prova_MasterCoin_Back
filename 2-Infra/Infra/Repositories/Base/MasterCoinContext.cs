using Domain.Entities.Entity;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;

namespace Infra.Repositories.Base
{
    public class MasterCoinContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptions)
        {

            if (!contextOptions.IsConfigured)
            {
                contextOptions.UseNpgsql("Server=localhost; userid=postgres; password=1234;database=BD_MC;");
                contextOptions.EnableSensitiveDataLogging();
            }


            base.OnConfiguring(contextOptions);
        }



        protected override void OnModelCreating(ModelBuilder model)
        {

            model.Ignore<Notification>();

            model.ApplyConfiguration<Usuario>(new UsuarioMapp());


            base.OnModelCreating(model);
        }
    }
}
