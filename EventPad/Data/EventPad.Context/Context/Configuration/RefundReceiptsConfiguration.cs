namespace EventPad.Context;

using Microsoft.EntityFrameworkCore;
using EventPad.Context.Entities;

public static class RefundReceiptsConfiguration
{
    public static void ConfigureRefundReceipts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RefundReceipt>().ToTable("refund_receipts");

        modelBuilder.Entity<RefundReceipt>().Property(x => x.Amount).IsRequired();
        modelBuilder.Entity<RefundReceipt>().Property(x => x.DateTime).IsRequired();

        modelBuilder.Entity<RefundReceipt>().HasOne(x => x.UserAccount).WithMany(x => x.Refunds).HasForeignKey(x => x.UserAccountId);
        modelBuilder.Entity<RefundReceipt>().HasOne(x => x.EventTicket).WithMany(x => x.Refunds).HasForeignKey(x => x.EventTicketId);
    }
}
