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
using System.Windows.Shapes;

namespace Dialogs2
{
    /// <summary>
    /// Interaction logic for ModelessWindow.xaml
    /// </summary>
    public partial class ModelessWindow : Window
    {
        public ModelessWindow()
        {
            InitializeComponent();
        }

        public event EventHandler Apply;

        public string stringThing { get; set; }
        public int intThing { get; set; }
        
        private void ButtonApply_Click(object sender, RoutedEventArgs e)
        {
            Apply?.Invoke(this, null);
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            ButtonApply_Click(this, null);
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
