namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class EventAccountContextConfiguration
{
    public static void ConfigureEventAccounts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventAccount>().ToTable("event_accounts");

        modelBuilder.Entity<EventAccount>().Property(x => x.AccountNumber).IsRequired();
        modelBuilder.Entity<EventAccount>().Property(x => x.AccountNumber).HasMaxLength(16);
        modelBuilder.Entity<EventAccount>().HasIndex(x => x.AccountNumber).IsUnique();
        modelBuilder.Entity<EventAccount>().Property(x => x.Balance).IsRequired();

        modelBuilder.Entity<EventAccount>().HasOne(x => x.Event).WithOne(x => x.EventAccount).HasPrincipalKey<EventAccount>(x => x.EventId);
    }
}

