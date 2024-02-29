namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class PurchaseReceiptsConfiguration
{
    public static void ConfigurePurchaseReceipts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchaseReceipt>().ToTable("purchase_receipts");

        modelBuilder.Entity<PurchaseReceipt>().Property(x => x.Amount).IsRequired();
        modelBuilder.Entity<PurchaseReceipt>().Property(x => x.DateTime).IsRequired();

        modelBuilder.Entity<PurchaseReceipt>().HasOne(x => x.UserAccount).WithMany(x => x.Purchases).HasForeignKey(x => x.UserAccountId);
        modelBuilder.Entity<PurchaseReceipt>().HasOne(x => x.SpecificEvent).WithMany(x => x.Purchases).HasForeignKey(x => x.SpecificEventId);
    }
}