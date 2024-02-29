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
    public DbSet<SpecificEvent> SpecificEvents { get; set; }
    public DbSet<PurchaseReceipt> PurchaseReceipts { get; set; }
    public DbSet<RefundReceipt> RefundReceipts { get; set; }
    public DbSet<DepositReceipt> DepositReceipts { get; set; }
    public DbSet<CashoutReceipt> CashoutReceipts { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureUsers();
        modelBuilder.ConfigureUserAccounts();
        modelBuilder.ConfigureEvents();
        modelBuilder.ConfigureEventAccounts();
        modelBuilder.ConfigureEventPhotos();
        modelBuilder.ConfigureEventSpecificEvents();
        modelBuilder.ConfigureEventTickets();
        modelBuilder.ConfigureCashoutEventReceipts();
        modelBuilder.ConfigureCashoutReceipts();
        modelBuilder.ConfigureDepositReceipts();
        modelBuilder.ConfigureRefundReceipts();
        modelBuilder.ConfigurePurchaseReceipts();
    }
}
