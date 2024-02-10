namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class EventTicketsContextConfiguration
{
    public static void ConfigureEventTickets(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventTicket>().ToTable("event_tickets");

        modelBuilder.Entity<EventTicket>().Property(x => x.DateTime).IsRequired();
        modelBuilder.Entity<EventTicket>().Property(x => x.ArticleNumber).IsRequired();
        modelBuilder.Entity<EventTicket>().Property(x => x.ArticleNumber).HasMaxLength(5);
        modelBuilder.Entity<EventTicket>().Property(x => x.Status).IsRequired();

        modelBuilder.Entity<EventTicket>().HasOne(x => x.Event).WithMany(x => x.Tickets).HasForeignKey(x => x.EventId);
    }
}
