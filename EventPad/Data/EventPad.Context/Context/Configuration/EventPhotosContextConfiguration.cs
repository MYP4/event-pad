namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class EventPhotosContextConfiguration
{
    public static void ConfigureEventPhotos(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventPhoto>().ToTable("event_photos");
        modelBuilder.Entity<EventPhoto>().Property(x => x.Path).IsRequired();

        modelBuilder.Entity<EventPhoto>().HasOne(x => x.Event).WithMany(x => x.Photos).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.Restrict);
    }
}

