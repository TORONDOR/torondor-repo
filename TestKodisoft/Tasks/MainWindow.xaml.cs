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
using Task5.Interfaces;
using System.Net;
using Newtonsoft.Json;

namespace Task5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int counter = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Queue<int> randomNumberQueue = new Queue<int>();
            INumberGenerator test = new NumberGenerator();
            try
            {
                randomNumberQueue = await test.GetNumberSequenceAsync(10);
            }
            catch (WebException exc)
            {
                randomNumberQueue = test.GetRandomNumbersUsingBCL(10);
            }
            finally
            {

                foreach (int value in randomNumberQueue)
                {
                    someSurface.Content += String.Format("Random number {0} : {1}\n\r", counter, value);
                    counter++;
                }
            }
        }
    }
}
