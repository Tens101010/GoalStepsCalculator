using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public enum PaymentTypeOption
    {
        CreditCard = 1,
        PayPal = 2
    }

    public class Payment
    {
        public int PaymentType { get; set; }

        public void ProcessPayment()
        {
            //-- Process the payment
            //If credit card, process the credit card payment
            //If PayPal, process PayPal payment
            //If there is a payment problem, notify the user
            //Open a connection
            //Set stored procedure parameters with the payment data
            //Call the save stored procedure

            PaymentTypeOption paymentTypeOption;
            if (!Enum.TryParse(this.PaymentType.ToString(), out paymentTypeOption))
            {
                throw new InvalidEnumArgumentException("Payment type", (int)this.PaymentType, typeof(PaymentTypeOption));
            }

            switch (paymentTypeOption)
            {
                case PaymentTypeOption.CreditCard:
                    // Process Credit Card
                    break;
                case PaymentTypeOption.PayPal:
                    // Process PayPal
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
