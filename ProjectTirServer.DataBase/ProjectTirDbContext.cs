using Microsoft.EntityFrameworkCore;
using ProjectTirServer.DataBase.Configurations;
using ProjectTirServer.DataBase.Entities;

namespace ProjectTirServer.DataBase
{
    public class ProjectTirDbContext : DbContext
    {
        public ProjectTirDbContext(DbContextOptions<ProjectTirDbContext> options)
            :base(options) 
        { 

        }


        public DbSet<UserEntity> Users { get; set; }

        public DbSet<SessionEntity> Sessions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
