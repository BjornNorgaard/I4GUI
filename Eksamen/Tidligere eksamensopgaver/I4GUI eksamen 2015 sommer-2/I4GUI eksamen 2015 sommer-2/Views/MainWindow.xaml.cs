using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using JsonSerializer;

namespace I4GUI_eksamen_2015_sommer_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Plan _plan;
        private Plan _log;

        readonly JsonSerializer<Plan> _json = new JsonSerializer<Plan>("plan");

        private LogWindow _logWindow;

        public MainWindow()
        {
            InitializeComponent();

            _plan = (Plan)FindResource("Plan");
            _log = (Plan)FindResource("Log");

            Closing += OnClosing;

            if (_json.FolderExists() == true)
            {
                _plan = _json.Deserialize();
            }
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            _json.Serialize(_plan);
        }

        private void MenuItem_Opret_OnClick(object sender, RoutedEventArgs e)
        {
            CreatePlanWindow dlg = new CreatePlanWindow();
            dlg.Owner = this;
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (dlg.ShowDialog() == true)
            {
                _plan.Add(dlg.NewPlanItem);
                _json.Serialize(_plan);
            }
        }

        private void MenuItem_Tag_OnClick(object sender, RoutedEventArgs e)
        {
            // find lowest time

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
