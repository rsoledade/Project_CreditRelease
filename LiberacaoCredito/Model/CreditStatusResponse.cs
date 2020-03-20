using System;
using System.Collections.Generic;
using System.Text;

namespace CreditRelease.Model
{
    public class CreditStatusResponse
    {
        public bool StatusCredit { get; set; }
        public decimal TotalAmountInterest { get; set; }
        public decimal InterestAmount { get; set; }
    }
}
