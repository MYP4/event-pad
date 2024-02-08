using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public class CashoutReceipt : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public string BankAccount { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateTime { get; set; }
    public string RKTransactionId { get; set; }
}
