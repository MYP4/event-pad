using EventPad.Context.Entities;

namespace EventPad.Services.Tickets;

public class TicketModel
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public DateTime? DateTime { get; set; }
    public bool Private { get; set; }
    public string ArticleNumber { get; set; }
    public TicketStatus Status { get; set; }    
}
