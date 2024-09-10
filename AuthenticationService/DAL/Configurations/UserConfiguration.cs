using AuthenticationService.DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthenticationService.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("bigint")
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique(); 

            builder.Property(u => u.UserName)
                .HasMaxLength(100)                          
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();

           builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Password)
                .HasMaxLength(512)
                .IsRequired()
                .HasComment("User password stored as a hash");
        }
    }
}
