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

namespace I4GUI_eksamen_2015_sommer_2.Views
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public Plan _log { get; set; }

        public event EventHandler CloseClicked;

        public LogWindow()
        {
            InitializeComponent();
            _log = (Plan)FindResource("Log");

        }

        private void ButtonBase_Close_OnClick(object sender, RoutedEventArgs e)
        {
            OnClose();
            Close();
        }

        protected virtual void OnClose()
        {
            CloseClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
