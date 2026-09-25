using System;
using System.Collections.Generic;
using PaymentPlus;

class Program
{
    public static void Main(string[] args)
    {
        List<Payment> samplePayments = new List<Payment>{
            // Valid CreditCardPayments
            new CreditCardPayment("2345 5356 6465 6455", "01/25", 334, "VISA", 11.10m, "CAD"),  // Valid (above $5.00 CAD)
            new CreditCardPayment("2145 5342 6879 1111", "01/25", 334, "VISA", 15.00m, "EUR"),  // Valid (above €10.00 EUR)

            // Invalid CreditCardPayments
            new CreditCardPayment("2315 7589 6465 4456", "01/25", 334, "VISA", 9.99m, "USD"),   // Invalid (Ends in .99)
            new CreditCardPayment("2315 7589 6465 4456", "01/25", 334, "VISA", 2.00m, "USD"),   // Invalid (below $5.00 USD)
            new CreditCardPayment("1345 7841 2345 2222", "01/25", 334, "VISA", 9.00m, "EUR"),   // Invalid (below €10.00 EUR)

            // Valid BitcoinPayments
            new BitcoinPayment("WID#5314321", "PayPal", 21.20, "USD"),  // Valid (above $5.00 USD)
            new BitcoinPayment("WID#234435781", "Stripe", 33.20, "CAD"),  // Valid (above $5.00 CAD)

            // Invalid BitcoinPayment
            new BitcoinPayment("WID#533462921", "Stripe", 4.50, "USD"),   // Invalid (below $5.00 USD)
            new BitcoinPayment("WID#234435781", "Stripe", 33.99, "CAD"),  // Invalid (ends in .99)


            // Valid CashPayments
            new CashPayment(6543.99, "USD"),   // Valid (cash can end in .99)
    
            // Invalid CashPayments
            new CashPayment(6543.00, "EUR"),   // Invalid (cash not accepted in EUR)

            // Valid ChequePayments
            new ChequePayment(42156, "ScotiaBank", 6341.00, "CAD"),  // Valid (whole amount in CAD)
            new ChequePayment(42156, "ScotiaBank", 6341.32, "CAD"),  // Valid (non whole amount but in CAD)
            new ChequePayment(42156, "ScotiaBank", 3000.00, "USD"),  // Valid (whole amount in USD)
    
            // Invalid ChequePayments
            new ChequePayment(42156, "ScotiaBank", 6341.05, "USD"),  // Invalid (non-whole amount in USD)
            new ChequePayment(42156, "ScotiaBank", 1500.98, "EUR"),   // Invalid (non-whole amount in EUR)
        };

        PaymentManager paymentManager = new PaymentManager();
        foreach (Payment payment in samplePayments)
            paymentManager.AddPayment(payment);

        paymentManager.ValidatePayments();
        paymentManager.AuthorizePayments();
        paymentManager.RecordOffline();
        paymentManager.ProcessPayments();
     }
}
/* OUTPUT:
 * 
Credit Card Payment of 9.99 USD from Credit Card number **** **** **** 4456 through VISA gateway was not valid, hence removed from the list.
Credit Card Payment of 2 USD from Credit Card number **** **** **** 4456 through VISA gateway was not valid, hence removed from the list.
Credit Card Payment of 9 EUR from Credit Card number **** **** **** 2222 through VISA gateway was not valid, hence removed from the list.
BTC Payment of 4.5 USD from WalletID WID#533462921 through Stripe gateway was not valid, hence removed from the list.
BTC Payment of 33.99 CAD from WalletID WID#234435781 through Stripe gateway was not valid, hence removed from the list.
Cash Payment of 6543 EUR was not valid, hence removed from the list.
Cheque Payment of 6341.05 USD with cheque number 42156 from Bank ScotiaBank was not valid, hence removed from the list.
Cheque Payment of 1500.98 EUR with cheque number 42156 from Bank ScotiaBank was not valid, hence removed from the list.
Credit Card Payment Authorized.
Credit Card Payment Authorized.
Bitcoin Payment Authorized.
Bitcoin Payment Authorized.
Cash Payment was recorded.
Cheque Payment was recorded.
Cheque Payment was recorded.
Cheque Payment was recorded.
Credit Card Payment successfully processed.
Credit Card Payment successfully processed.
Bitcoin Payment successfully processed.
Bitcoin Payment successfully processed.
Bitcoin Payment successfully processed.
Cheque Payment successfully processed.
Cheque Payment successfully processed.
Cheque Payment successfully processed.
*/