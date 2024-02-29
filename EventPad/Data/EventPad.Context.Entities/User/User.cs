using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }


    public virtual UserAccount Account { get; set; }

    public virtual ICollection<Event>? Events { get; set; }
    public virtual ICollection<CashoutEventReceipt>? CashoutEventReceipts { get; set; }
    public virtual ICollection<EventTicket>? EventTickets { get; set; }
}
