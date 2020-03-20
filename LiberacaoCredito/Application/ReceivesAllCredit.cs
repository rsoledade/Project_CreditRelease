using CreditRelease.Model;
using CreditRelease.Services;

namespace CreditRelease.Application
{
    public class ReceivesAllCredit
    {
        PaymentProcessing paymentProcessing;

        public ReceivesAllCredit()
        {
            paymentProcessing = new PaymentProcessing();
        }

        public CreditStatusResponse ValidateCredit(CreditRequest creditRequest)
        {
            return paymentProcessing.FilterCreditType(creditRequest);
        }
    }
}
