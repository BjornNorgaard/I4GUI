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

        private ModelessWindow _modelessWindow = null;

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
            if (_modelessWindow != null) _modelessWindow.Focus();
            else
            {
                _modelessWindow = new ModelessWindow();
                _modelessWindow.Owner = this;
                _modelessWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                _modelessWindow.stringThing = Properties.Settings.Default.testString;
                _modelessWindow.intThing = Properties.Settings.Default.testInt;

                _modelessWindow.Apply += Modeless_Apply;
                _modelessWindow.Closing += Modeless_Closed;

                _modelessWindow.Show();
            }
        }

        private void Modeless_Apply(object sender, EventArgs e)
        {
            ModelessWindow dlg = (ModelessWindow) sender;

            Properties.Settings.Default.testString = _modelessWindow.stringThing;
            Properties.Settings.Default.testInt = _modelessWindow.intThing;

            StringBlock.Text = Properties.Settings.Default.testString;
            IntBlock.Text = Properties.Settings.Default.testInt.ToString();
        }

        private void Modeless_Closed(object sender, EventArgs e)
        {
            _modelessWindow = null;
            Focus();
        }
    }
}
