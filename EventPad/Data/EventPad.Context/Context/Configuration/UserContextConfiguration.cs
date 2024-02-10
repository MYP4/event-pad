namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class UserContextConfiguration
{
    public static void ConfigureUsers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
    }
}
