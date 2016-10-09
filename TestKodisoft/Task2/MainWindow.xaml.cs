using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Task2
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

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Task task1 = Task.Run(() => Test());
            task1.ContinueInMainThread(() => { label1.Content = "Action Finished"; });
            label1.Content = "Action in process";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(t => Test(), TaskScheduler.Default).
                ContinueInMainThread(t => label1.Content = "Action<Task> test finished");
            label1.Content = "Action in process";
        }

        private void Test()
        {
            Thread.Sleep(5000);
        }
    }
}
