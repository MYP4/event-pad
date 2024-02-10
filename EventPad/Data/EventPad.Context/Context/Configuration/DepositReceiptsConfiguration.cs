namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class DepositReceiptsConfiguration
{
    public static void ConfigureDepositReceipts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepositReceipt>().ToTable("deposit_receipts");

        modelBuilder.Entity<DepositReceipt>().Property(x => x.Amount).IsRequired();
        modelBuilder.Entity<DepositReceipt>().Property(x => x.DateTime).IsRequired();
        modelBuilder.Entity<DepositReceipt>().Property(x => x.RKTransactionId).IsRequired();

        modelBuilder.Entity<DepositReceipt>().HasOne(x => x.UserAccount).WithMany(x => x.Deposits).HasForeignKey(x => x.UserAccountId);
    }
}