using System;
using System.Collections.Generic;
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
using System.Xml.Schema;

namespace Threading
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

        private string taskText = "";

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            tbStatus.Text = "Task started!";
            await Task.Run(() => TakesForever());
            tbStatus.Text = "Task completed!";
        }

        private void TakesForever()
        {
            Thread.Sleep(2000);
        }
    }
}
