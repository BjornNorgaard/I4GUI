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

namespace Dialogs
{
    /// <summary>
    /// Interaction logic for WindowModal.xaml
    /// </summary>
    public partial class WindowModal : Window
    {
        public string StringProperty { get; set; }
        public int IntegerProperty { get; set; }

        public WindowModal()
        {
            InitializeComponent();

            StringProperty = "Hello World!";
            IntegerProperty = 42;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
