using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTirServer.DataBase.Entities;

namespace ProjectTirServer.DataBase.Configurations
{
    internal class SessionConfiguration : IEntityTypeConfiguration<SessionEntity>
    {
        public void Configure(EntityTypeBuilder<SessionEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.UserId)
                .IsRequired();

            builder.HasOne(s => s.User)
                .WithMany(u => u.OpenSessions)
                .HasForeignKey(s => s.UserId);
        }
    }
}
