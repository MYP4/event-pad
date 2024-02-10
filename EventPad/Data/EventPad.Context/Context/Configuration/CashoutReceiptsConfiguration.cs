namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class CashoutReceiptsConfiguration
{
    public static void ConfigureCashoutReceipts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CashoutReceipt>().ToTable("cashout_receipts");

        modelBuilder.Entity<CashoutReceipt>().Property(x => x.BankAccount).IsRequired();
        modelBuilder.Entity<CashoutReceipt>().Property(x => x.Amount).IsRequired();
        modelBuilder.Entity<CashoutReceipt>().Property(x => x.DateTime).IsRequired();
        modelBuilder.Entity<CashoutReceipt>().Property(x => x.RKTransactionId).IsRequired();

        modelBuilder.Entity<CashoutReceipt>().HasOne(x => x.UserAccount).WithMany(x => x.Cashouts).HasForeignKey(x => x.UserAccountId);
    }
}
