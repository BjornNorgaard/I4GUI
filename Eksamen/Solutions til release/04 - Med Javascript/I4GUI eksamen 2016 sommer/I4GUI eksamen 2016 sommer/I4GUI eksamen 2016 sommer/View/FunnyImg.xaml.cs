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

namespace I4GUI_eksamen_2016_sommer
{
    public partial class FunnyImg : Window
    {
        public event EventHandler CloseEvent;

        public FunnyImg()
        {
            InitializeComponent();
        }

        protected virtual void OnClose()
        {
            CloseEvent?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonBase_Close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
            OnClose();
        }
    }
}
