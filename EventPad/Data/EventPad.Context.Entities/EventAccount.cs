namespace EventPad.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class EventAccount
{
    [Key]
    public int EventId { get; set; }
    public virtual Event Event { get; set; }

    public string AccountNumber {  get; set; }
    public float Balance { get; set; }

    public virtual ICollection<CashoutEventReceipt>? Cashouts { get; set;}
}
