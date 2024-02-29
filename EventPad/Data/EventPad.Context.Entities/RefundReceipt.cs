using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public class RefundReceipt : BaseEntity
{
    public int UserAccountId { get; set; }
    public virtual UserAccount UserAccount { get; set; }

    public int SpecificEventId { get; set; }
    public virtual SpecificEvent SpecificEvent { get; set; }

    public float Amount { get; set; }
    public DateTime DateTime { get; set; }
    public string? Description { get; set; }
}
