using CreditRelease.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditRelease.Services
{
    public class PaymentProcessing
    {
        //Credito Direto - Taxa de 2% ao mês
        //Credito Consignado - Taxa de 1% ao mês
        //Credito Pessoa Jurídica - Taxa de 5% ao mês
        //Credito Pessoa Física - Taxa de 3% ao mês
        //Credito Imobiliário - Taxa de 9% ao ano

        private const decimal _directCredit = 0.02M;
        private const decimal _payrollLoans = 0.01M;
        private const decimal _legalEntityCredit = 0.05M;
        private const decimal _individualCredit = 0.03M;
        private const decimal _realEstateCredit = 0.09M;
        private const decimal _maximumCredit = 1000000M;
        private const decimal _minimumCredit = 15000M;

        private Credit credit;
        private CreditStatusResponse creditStatusResponse;

        public PaymentProcessing()
        {
            credit = new Credit();
            creditStatusResponse = new CreditStatusResponse();
        }

        public CreditStatusResponse FilterCreditType(CreditRequest creditRequest)
        {
            var _creditConvert = ConvertObjects(creditRequest);
            return creditStatusResponse = ProcessesCredit(_creditConvert);
        }
        
        public CreditStatusResponse ProcessesCredit(Credit credit)
        {
            switch (credit.CreditType)
            {
                case (int)TypeCredit.DirectCredit:
                    creditStatusResponse = CalculateDirectCredit(credit);                    
                    break;

                case (int)TypeCredit.PayrollLoans:
                    creditStatusResponse = CalculatePayrollLoans(credit);
                    break;

                case (int)TypeCredit.LegalEntityCredit:
                    creditStatusResponse = CalculateLegalEntityCredit(credit);
                    break;

                case (int)TypeCredit.IndividualCredit:
                    creditStatusResponse = CalculateIndividualCredit(credit);
                    break;

                case (int)TypeCredit.RealEstateCredit:
                    creditStatusResponse = CalculateRealEstateCredit(credit);
                    break;

                default:
                    break;
            }

            return creditStatusResponse;
        }

        private CreditStatusResponse CalculateDirectCredit(Credit credit)
        {
            decimal creditAmount = credit.CreditAmount;
            credit.CreditAmount += credit.CreditAmount * _directCredit;
            decimal interestAmount = creditAmount * _directCredit;

            if (credit.CreditAmount > _maximumCredit)
            {
                creditStatusResponse.StatusCredit = false;
                creditStatusResponse.InterestAmount = credit.CreditAmount;
                creditStatusResponse.TotalAmountInterest = interestAmount;
            }

            else
            {
                creditStatusResponse.StatusCredit = true;
                creditStatusResponse.InterestAmount = credit.CreditAmount;
                creditStatusResponse.TotalAmountInterest = interestAmount;
            }

            return creditStatusResponse;
        }

        private CreditStatusResponse CalculatePayrollLoans(Credit credit)
        {
            decimal creditAmount = credit.CreditAmount;
            credit.CreditAmount += credit.CreditAmount * _payrollLoans;
            decimal interestAmount = creditAmount * _payrollLoans;

            if (credit.CreditAmount > _maximumCredit)
            {
                creditStatusResponse.StatusCredit = false;
                creditStatusResponse.InterestAmount = credit.CreditAmount;
                creditStatusResponse.TotalAmountInterest = interestAmount;
            }

            else
            {
                creditStatusResponse.StatusCredit = true;
                creditStatusResponse.InterestAmount = credit.CreditAmount;
                creditStatusResponse.TotalAmountInterest = interestAmount;
            }

            return creditStatusResponse;
        }

        private CreditStatusResponse CalculateLegalEntityCredit(Credit credit)
        {
            decimal creditAmount = credit.CreditAmount;
            credit.CreditAmount += credit.CreditAmount * _legalEntityCredit;
            decimal interestAmount = creditAmount * _legalEntityCredit;

            if (credit.CreditAmount < _minimumCredit || credit.CreditAmount > _maximumCredit)
            {
                creditStatusResponse.StatusCredit = false;
                creditStatusResponse.InterestAmount = credit.CreditAmount;
                creditStatusResponse.TotalAmountInterest = interestAmount;
            }

            else
            {
                creditStatusResponse.StatusCredit = true;
                creditStatusResponse.InterestAmount = credit.CreditAmount;
                creditStatusResponse.TotalAmountInterest = interestAmount;
            }

            return creditStatusResponse;
        }

        private CreditStatusResponse CalculateIndividualCredit(Credit credit)
        {
            decimal creditAmount = credit.CreditAmount;
            credit.CreditAmount += credit.CreditAmount * _individualCredit;
            decimal interestAmount = creditAmount * _individualCredit;

            if (credit.CreditAmount > _maximumCredit)
            {
                creditStatusResponse.StatusCredit = false;
                creditStatusResponse.InterestAmount = credit.CreditAmount;
                creditStatusResponse.TotalAmountInterest = interestAmount;
            }

            else
            {
                creditStatusResponse.StatusCredit = true;
                creditStatusResponse.InterestAmount = credit.CreditAmount;
                creditStatusResponse.TotalAmountInterest = interestAmount;
            }

            return creditStatusResponse;
        }

        private CreditStatusResponse CalculateRealEstateCredit(Credit credit)
        {
            decimal creditAmount = credit.CreditAmount;
            credit.CreditAmount += credit.CreditAmount * _realEstateCredit;
            decimal interestAmount = creditAmount * _realEstateCredit;

            if (credit.CreditAmount > _maximumCredit)
            {
                creditStatusResponse.StatusCredit = false;
                creditStatusResponse.InterestAmount = credit.CreditAmount;
                creditStatusResponse.TotalAmountInterest = interestAmount;
            }

            else
            {
                creditStatusResponse.StatusCredit = true;
                creditStatusResponse.InterestAmount = credit.CreditAmount;
                creditStatusResponse.TotalAmountInterest = interestAmount;
            }

            return creditStatusResponse;
        }

        private Credit ConvertObjects(CreditRequest creditRequest)
        {
            credit.CreditType = creditRequest.CreditType;
            credit.CreditAmount = creditRequest.CreditAmount;
            credit.QuantityPlots = creditRequest.QuantityPlots;
            credit.FirstDueDate = creditRequest.FirstDueDate;

            return credit;
        }


    }
}
