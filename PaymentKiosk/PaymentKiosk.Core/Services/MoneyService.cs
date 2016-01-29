using PaymentKiosk.Core.Domain;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PaymentKiosk.Core.Services
{
    public class MoneyService
    {
        private const string StripeApiKey = "sk_test_wNpc6qJWVMqILZAAUET9gbUg";

        public static bool Charge(Customer customer, CreditCard creditCard, decimal amount)
        {
            var chargeDetails = new StripeChargeCreateOptions();

            chargeDetails.Amount = (int)amount * 100;
            chargeDetails.Currency = "usd";

            chargeDetails.Source = new StripeSourceOptions
            {
                Object = "card",
                Number = creditCard.CardNumber,
                ExpirationMonth = creditCard.ExpireyDate.Month.ToString(),
                ExpirationYear = creditCard.ExpireyDate.Year.ToString(),
                Cvc = creditCard.Cvc,
            };

            var chargeService = new StripeChargeService(StripeApiKey);
            var response = chargeService.Create(chargeDetails);

            if (response.Paid == false)
            {
                throw new Exception(response.FailureMessage);
            }

            return response.Paid;
        }
    }
}
