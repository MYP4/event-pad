namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class CashoutEventReceiptsContextConfiguration
{
    public static void ConfigureCashoutEventReceipts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CashoutEventReceipt>().ToTable("cashout_event_receipts");

        modelBuilder.Entity<CashoutEventReceipt>().Property(x => x.BankAccount).IsRequired();
        modelBuilder.Entity<CashoutEventReceipt>().Property(x => x.Amount).IsRequired();
        modelBuilder.Entity<CashoutEventReceipt>().Property(x => x.DateTime).IsRequired();
        modelBuilder.Entity<CashoutEventReceipt>().Property(x => x.RKTransactionId).IsRequired();

        modelBuilder.Entity<CashoutEventReceipt>().HasOne(x => x.Account).WithMany(x => x.Cashouts).HasForeignKey(x => x.EventAccountId);
        modelBuilder.Entity<CashoutEventReceipt>().HasOne(x => x.User).WithMany(x => x.CashoutEventReceipts).HasForeignKey(x => x.UserId);
    }
}
