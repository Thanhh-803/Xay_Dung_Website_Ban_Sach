using GameStore.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Areas.Identity.Data;

public class DbContextGameStore : IdentityDbContext<GameStoreUser>
{
    public DbContextGameStore(DbContextOptions<DbContextGameStore> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}



public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<GameStoreUser>
{
    public void Configure(EntityTypeBuilder<GameStoreUser> builder)
    {
        builder.Property(x => x.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
        builder.Property(x => x.Email).HasMaxLength(50);
        builder.Property(x => x.Password).HasMaxLength(50);
    }
}
