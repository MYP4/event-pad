    namespace EventPad.Services.CashoutEventReceipts;

public class EventCashoutModelFilter
{
    public Guid? EventAccount {  get; set; }
    public Guid? User {  get; set; }
    public string? BankNumber { get; set; }
    public DateTime? DateTime { get; set; }
}
