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
using Microsoft.Win32;

namespace Dialogs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string StringProperty { get; set; }
        public int IntegerProperty { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ModalLable.Content = Properties.Settings.Default.StringProperty;
            ModelessLabel.Content = Properties.Settings.Default.IntegerProperty;
        }

        private void Button_SpawnModalDialog(object sender, RoutedEventArgs e)
        {
            // dialog stuff
            WindowModal dlg = new WindowModal();
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dlg.Owner = this;

            dlg.StringProperty = Properties.Settings.Default.StringProperty;
            dlg.IntegerProperty = Properties.Settings.Default.IntegerProperty;

            if (dlg.ShowDialog() == true)
            {
                // do stuff
                Properties.Settings.Default.StringProperty = dlg.StringProperty;
                Properties.Settings.Default.IntegerProperty = dlg.IntegerProperty;
                Properties.Settings.Default.Save();
            }
        }

        private void Button_SpawnModelessDialog(object sender, RoutedEventArgs e)
        {
            // dialog stuff
            WindowModal dlg = new WindowModal();
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dlg.Owner = this;
            dlg.Show();
        }
    }
}
