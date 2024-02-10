namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class UserAccountsConfiguration
{
    public static void ConfigureUserAccounts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAccount>().ToTable("user_accounts");

        modelBuilder.Entity<UserAccount>().Property(x => x.AccountNumber).IsRequired();
        modelBuilder.Entity<UserAccount>().Property(x => x.AccountNumber).HasMaxLength(16);
        modelBuilder.Entity<UserAccount>().HasIndex(x => x.AccountNumber).IsUnique();
        modelBuilder.Entity<UserAccount>().Property(x => x.Balance).IsRequired();

        modelBuilder.Entity<UserAccount>().HasOne(x => x.User).WithOne(x => x.Account).HasPrincipalKey<UserAccount>(x => x.UserId);
    }
}
