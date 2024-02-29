namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class EventSpecificEventsContextConfiguration
{
    public static void ConfigureEventTickets(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SpecificEvent>().ToTable("specific_events");

        modelBuilder.Entity<SpecificEvent>().Property(x => x.DateTime).IsRequired();
        modelBuilder.Entity<SpecificEvent>().Property(x => x.ArticleNumber).IsRequired();
        modelBuilder.Entity<SpecificEvent>().Property(x => x.ArticleNumber).HasMaxLength(50);
        modelBuilder.Entity<SpecificEvent>().Property(x => x.Status).IsRequired();

        modelBuilder.Entity<SpecificEvent>().HasOne(x => x.Event).WithMany(x => x.SpecificEvents).HasForeignKey(x => x.EventId);
    }
}
