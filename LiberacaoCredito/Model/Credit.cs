using System;

namespace CreditRelease.Model
{
    public class Credit
    {
        public decimal CreditAmount { get; set; }
        public int CreditType { get; set; }
        public int QuantityPlots { get; set; }
        public DateTime FirstDueDate { get; set; }
    }
}
