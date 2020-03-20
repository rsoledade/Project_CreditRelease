using System;

namespace CreditRelease.Model
{
    public class CreditRequest
    {
        public decimal CreditAmount { get; set; }
        public int CreditType { get; set; }
        public int QuantityPlots { get; set; }
        public DateTime FirstDueDate { get; set; }
        public string ErrorMessage { get; set; }

        public bool Validate()
        {
            if (CreditAmount <= 0)
            {
                this.ErrorMessage = "Credit value cannot be zero";
            }

            else if (CreditAmount > 1000000)
            {
                this.ErrorMessage = "The maximum credit amount is one million";
            }

            else if (QuantityPlots <= 0)
            {
                this.ErrorMessage = "Quantity plots is required";
            }

            else if (QuantityPlots < 5 || QuantityPlots > 72)
            {
                this.ErrorMessage = "The minimum number of installments is 5 and the maximum number is 72";
            }

            else if (CreditType <= 0)
            {
                this.ErrorMessage = "Credit type is required";
            }            

            else if (String.IsNullOrEmpty(FirstDueDate.ToString()))
            {
                this.ErrorMessage = "Expiration date is required";
            }

            else if (FirstDueDate <= DateTime.MinValue || FirstDueDate >= DateTime.MaxValue)
            {
                this.ErrorMessage = "Enter a valid date";
            }

            else if (FirstDueDate < DateTime.Now.AddDays(+15) && FirstDueDate < DateTime.Now.AddDays(+40))
            {
                this.ErrorMessage = "The first due date is a minimum of 15 days and a maximum of 40 days";
            }

            else if (CreditType == 3)
            {
                if (CreditAmount < 15000)
                {
                    this.ErrorMessage = "The minimum credit amount for legal entities is 15000";
                }
            }

            return String.IsNullOrEmpty(this.ErrorMessage);
        }

        public string GetError()
        {
            return this.ErrorMessage;
        }
    }
}
