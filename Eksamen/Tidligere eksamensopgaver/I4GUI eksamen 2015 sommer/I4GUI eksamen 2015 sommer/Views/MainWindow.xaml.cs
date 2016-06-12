using System;
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
        Upcomming _upcomming = new Upcomming();

        public MainWindow()
        {
            InitializeComponent();

            Closing += OnClosing;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _upcomming.currentPlan = jsonSerializer.Deserialize();
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            Properties.Settings.Default.Save();
            jsonSerializer.OverwriteSerializeCollectionWithOtherCollection(_upcomming.currentPlan);
        }

        private void MenuItem_Opret_Clicked(object sender, RoutedEventArgs e)
        {
            CreatePlan dlg = new CreatePlan();
            dlg.Owner = this;
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (dlg.ShowDialog() == true)
            {
                Tuple<DateTime, string> infoTuple = new Tuple<DateTime, string>(dlg.MedTime, dlg.MedDescription);
                _upcomming.currentPlan.Add(infoTuple);
                jsonSerializer.SerializeObject(infoTuple);
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Tag_Clicked(object sender, RoutedEventArgs e)
        {
        }
    }
}
