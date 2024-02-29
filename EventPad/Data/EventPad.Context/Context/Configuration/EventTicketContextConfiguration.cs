namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class EventTicketContextConfiguration
{
    public static void ConfigureEventSpecificEvents(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventTicket>().ToTable("event_tickets");

        modelBuilder.Entity<EventTicket>().Property(x => x.Status).IsRequired();

        modelBuilder.Entity<EventTicket>().HasOne(x => x.User).WithMany(x => x.EventTickets).HasForeignKey(x => x.UserId);
        modelBuilder.Entity<EventTicket>().HasOne(x => x.SpecificEvent).WithMany(x => x.Tickets).HasForeignKey(x => x.EventTicketId);
    }
}
