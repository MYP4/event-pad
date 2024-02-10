using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public class PurchaseReceipt : BaseEntity
{
    public int UserAccountId { get; set; }
    public virtual UserAccount UserAccount { get; set; }

    public int EventTicketId { get; set; }
    public virtual EventTicket EventTicket { get; set; }

    public float Amount { get; set; }
    public DateTime DateTime { get; set; }
    public string? Description { get; set; }
}
