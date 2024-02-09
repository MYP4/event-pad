using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public class User : BaseEntity
{

    public virtual UserAccount Account { get; set; }

    public virtual ICollection<Event>? Events { get; set; }
    public virtual ICollection<CashoutEventReceipt>? CashoutEventReceipts { get; set; }
    public virtual ICollection<EventVisitor>? EventVisitors { get; set; }
}
