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
using JsonSerializer;

namespace I4GUI_eksamen_2015_sommer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JsonSerializer<Tuple<DateTime, string>> jsonSerializer = new JsonSerializer<Tuple<DateTime, string>>("medicinplan");
        private List<Tuple<DateTime, string>> currentPlan = new List<Tuple<DateTime, string>>();

        public MainWindow()
        {
            InitializeComponent();

            Closing += OnClosing;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            currentPlan = jsonSerializer.Deserialize();
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            Properties.Settings.Default.Save();
            jsonSerializer.OverwriteSerializeCollectionWithOtherCollection(currentPlan);
        }

        private void MenuItem_Opret_Clicked(object sender, RoutedEventArgs e)
        {
            CreatePlan dlg = new CreatePlan();
            dlg.Owner = this;
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (dlg.ShowDialog() == true)
            {
                Tuple<DateTime, string> infoTuple = new Tuple<DateTime, string>(dlg.MedTime, dlg.MedDescription);
                currentPlan.Add(infoTuple);
                jsonSerializer.SerializeObject(infoTuple);
            }
        }
    }
}
