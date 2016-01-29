using PaymentKiosk.Core.Domain;
using PaymentKiosk.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Twilio;

namespace PaymentKiosk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer
            {
                Name = textBoxCustomerName.Text,
                Telephone = textBoxCustomerPhone.Text
            };

            var creditCard = new CreditCard
            {
                CardNumber = textBoxCreditCard.Text,
                Cvc = textBoxSecurityCode.Text,
                ExpireyDate = DateTime.Parse(textBoxExpireyDate.Text),
            };

            bool success = MoneyService.Charge(customer, creditCard, decimal.Parse(textBoxAmount.Text));

            if(success)
            {
                SmsService.SendSms("+18184348962", "Payment Successful");
                MessageBox.Show("Payment Successful");
            }
            else
            { 
                SmsService.SendSms("+18184348962", "Payment Unsuccessful");
                MessageBox.Show("Payment Unsuccessful");
           }
        }

        public void SetTotal(decimal amount)
        {
            textBoxAmount.Text = amount.ToString();
        }
    }
}
