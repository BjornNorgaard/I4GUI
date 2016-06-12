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

        public MainWindow()
        {
            InitializeComponent();
            _plan = (Plan)FindResource("Plan");
        }

        private void MenuItem_Opret_OnClick(object sender, RoutedEventArgs e)
        {
            CreatePlanWindow dlg = new CreatePlanWindow();
            dlg.Owner = this;
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (dlg.ShowDialog() == true)
            {
                _plan.Add(dlg.newPlanItem);
            }
        }

        private void MenuItem_Tag_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_Luk_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonBase_ViewLog_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
