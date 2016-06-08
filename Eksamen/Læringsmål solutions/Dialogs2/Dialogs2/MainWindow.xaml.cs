using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Dialogs2
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

        private void ModalButton_Click(object sender, RoutedEventArgs e)
        {
            ModalWindow dlg = new ModalWindow();
            dlg.Owner = this;
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (dlg.ShowDialog() == true)
            {
                Properties.Settings.Default.testString = dlg.StringThing;
                Properties.Settings.Default.testInt = dlg.IntThing;
            }

            StringBlock.Text = Properties.Settings.Default.testString;
            IntBlock.Text = Properties.Settings.Default.testInt.ToString();
        }

        private void ModelessButton_Click(object sender, RoutedEventArgs e)
        {
            //ModalWindow dlg = new ModalWindow();
            //dlg.Owner = this;
            //dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //dlg.Show();

            //StringBlock.Text = Properties.Settings.Default.testString;
            //IntBlock.Text = Properties.Settings.Default.testInt.ToString();
        }
    }
}
