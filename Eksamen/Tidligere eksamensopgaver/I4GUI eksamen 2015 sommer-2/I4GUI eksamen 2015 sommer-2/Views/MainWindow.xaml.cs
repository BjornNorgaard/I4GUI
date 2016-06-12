using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using I4GUI_eksamen_2015_sommer_2.Views;

namespace I4GUI_eksamen_2015_sommer_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Plan _plan;
        private Plan _log;
        
        private LogWindow _logWindow;
        
        public MainWindow()
        {
            InitializeComponent();
            
            _plan = (Plan)FindResource("Plan");
            _log = (Plan)FindResource("Log");
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItem_Opret_OnClick(object sender, RoutedEventArgs e)
        {
            CreatePlanWindow dlg = new CreatePlanWindow();
            dlg.Owner = this;
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (dlg.ShowDialog() == true)
            {
                _plan.Add(dlg.NewPlanItem);
            }
        }

        private void MenuItem_Tag_OnClick(object sender, RoutedEventArgs e)
        {
            // insert in log
            _log.Add(_plan.First());

            // remove from plan
            _plan.Remove(_plan.First());
        }

        private void MenuItem_Luk_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonBase_ViewLog_OnClick(object sender, RoutedEventArgs e)
        {
            if (_logWindow != null) _logWindow.Focus();
            else
            {
                _logWindow = new LogWindow();
                _logWindow.Owner = this;
                _logWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                _logWindow.CloseClicked += Log_Closed;

                _logWindow.Show();
            }
        }

        private void Log_Closed(object sender, EventArgs e)
        {
            _logWindow = null;
            Focus();
        }
    }
}
