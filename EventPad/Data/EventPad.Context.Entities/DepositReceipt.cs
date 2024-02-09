using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public class DepositReceipt : BaseEntity
{
    public int UserAccountId { get; set; }
    public virtual User User { get; set; }

    public decimal Amount { get; set; }
    public DateTime DateTime { get; set; }
    public string RKTransactionId { get; set; }
}
