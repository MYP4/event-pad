using System.ComponentModel.DataAnnotations;

namespace EventPad.Context.Entities;

public  class UserAccount
{
    [Key]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }


    public virtual ICollection<DepositReceipt>? Deposits { get; set; }
    public virtual ICollection<CashoutReceipt>? Cashouts { get; set; }
    public virtual ICollection<PurchaseReceipt>? Purchases { get; set; }
    public virtual ICollection<RefundReceipt>? Refunds { get; set; }
}
