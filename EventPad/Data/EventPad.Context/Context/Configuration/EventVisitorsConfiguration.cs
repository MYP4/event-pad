namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class EventVisitorsConfiguration
{
    public static void ConfigureEventVisitors(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventVisitor>().ToTable("event_visitors");

        modelBuilder.Entity<EventVisitor>().Property(x => x.Status).IsRequired();

        modelBuilder.Entity<EventVisitor>().HasOne(x => x.User).WithMany(x => x.EventVisitors).HasForeignKey(x => x.UserId);
        modelBuilder.Entity<EventVisitor>().HasOne(x => x.EventTicket).WithMany(x => x.Visitors).HasForeignKey(x => x.EventTicketId);
    }
}
