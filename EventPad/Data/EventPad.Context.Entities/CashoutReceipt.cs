﻿using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public class CashoutReceipt : BaseEntity
{
    public int UserAccountId { get; set; }
    public virtual UserAccount UserAccount { get; set; }

    public string BankAccount { get; set; }
    public float Amount { get; set; }
    public DateTime DateTime { get; set; }
    public string RKTransactionId { get; set; }
}
