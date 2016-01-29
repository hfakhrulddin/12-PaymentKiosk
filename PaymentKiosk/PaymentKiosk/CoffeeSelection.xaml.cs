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
using System.Windows.Shapes;

namespace PaymentKiosk
{
    /// <summary>
    /// Interaction logic for CoffeeSelection.xaml
    /// </summary>
    public partial class CoffeeSelection : Window
    {
        
        public CoffeeSelection()
        {
            InitializeComponent();
        }

        public void getPrice()
        {
            var CoffeeValue = 0.0;
            var CreamSelection = 0.0;
            var SugarSelection = 0.0;

            if (radioButton1.IsChecked == true)
            {
                CoffeeValue = 1.50;
            }
            else if (radioButtony2.IsChecked == true)
            {
                CoffeeValue = 1.00;
            }
            else if (radioButtony3.IsChecked == true)
            {
                CoffeeValue = 2.50;
            }

            if (checkBox.IsChecked == true)
            {
                CreamSelection = .50;
            }
            else if (checkBox.IsChecked == false)
            {
                CreamSelection = .00;
            }

            if (checkBox1.IsChecked == true)
            {
                SugarSelection = .75;
            }
            else if (checkBox1.IsChecked == false)
            {
                SugarSelection = .00;
            }

            var totalCost = CoffeeValue + CreamSelection + SugarSelection;

            MainWindow window = new MainWindow();

            window.SetTotal((decimal)totalCost);

            window.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            getPrice();
        }
    }
}


