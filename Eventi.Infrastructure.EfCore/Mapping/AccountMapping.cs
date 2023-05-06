using Eventi.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class AccountMapping : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Fullname).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.Property(x => x.State).HasMaxLength(100);
        builder.Property(x => x.City).HasMaxLength(100);
        builder.Property(x => x.Password).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.ProfilePhoto).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Mobile).HasMaxLength(20).IsRequired();

        builder.HasOne(x => x.Role)
            .WithMany(x => x.Accounts)
            .HasForeignKey(x => x.RoleId);

        builder.HasMany(x => x.Orders)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId);

/*
        builder.HasData(new Account
        {
            Id = 1,
            CreationDate = DateTime.Now,
            Fullname = "ادمین",
            Mobile = "09123456789",
            Email = "test@gmail.com",
            Password = "10000.kAB/g7f2CTqNArwvmuP79A==.A/7rODRWAtQhTiimt+8P9Hi9i/w+QpZLUOcjvguC7a8=",
            ProfilePhoto = @"profilePhotos\DefaultProfilePicture.svg",
            RoleId = 1
        });
*/
    }

}