using EventPad.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPad.Context;

public class MainDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventAccount> EventAccounts { get; set; }
    public DbSet<EventPhoto> EventPhotos { get; set; }
    public DbSet<CashoutEventReceipt> CashoutEventReceipts { get; set; }
    public DbSet<EventTicket> EventTickets { get; set; }
    public DbSet<EventVisitor> EventVisitors { get; set; }
    public DbSet<PurchaseReceipt> PurchaseReceipts { get; set;}
    public DbSet<RefundReceipt> RefundReceipts { get; set;}
    public DbSet<DepositReceipt> DepositReceipts { get; set;}
    public DbSet<CashoutReceipt> CashoutReceipts { get; set;}
}
