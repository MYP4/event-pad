using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public class CashoutEventReceipt : BaseEntity
{
    public int EventAccountId { get; set; }
    public virtual EventAccount Account { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }

    public string BankAccount { get; set; }
    public float Amount { get; set; }
    public DateTime DateTime {  get; set; }
    public string RKTransactionId { get; set; }
}
