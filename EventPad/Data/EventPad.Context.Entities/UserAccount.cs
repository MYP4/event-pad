using System.ComponentModel.DataAnnotations;

namespace EventPad.Context.Entities;

public  class UserAccount
{
    [Key]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
}
