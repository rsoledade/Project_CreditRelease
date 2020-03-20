using CreditRelease.Application;
using CreditRelease.Model;
using System;

namespace CreditRelease
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Creates the credit parameters to be searched
                CreateParametersRequisition();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void CreateParametersRequisition()
        {
            // Fill in your query parameters here
            var creditRequest = new CreditRequest
            {
                CreditType = 3,
                CreditAmount = 85000,
                FirstDueDate = DateTime.Now,
                QuantityPlots = 12
            };

            ValidateCredit(creditRequest);
        }

        private static void ValidateCredit(CreditRequest creditRequest)
        {
            if (creditRequest.Validate())
            {
                var receiveCredit = new ReceivesAllCredit();
                var creditResponse = receiveCredit.ValidateCredit(creditRequest);
                Console.WriteLine("Credit status: " + creditResponse.StatusCredit + "\n" + "Total amount with interest:" +
                    creditResponse.InterestAmount + "\n" + "Interest amount: " + creditResponse.TotalAmountInterest);
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine(creditRequest.GetError());
                Console.ReadKey();
            }

        }

    }
}
