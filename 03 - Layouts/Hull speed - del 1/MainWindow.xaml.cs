using System.Windows;

namespace Hull_speed___del_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sailboat sailboat = new Sailboat();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            sailboat.Name = NameBox.Text;
            sailboat.Length = double.Parse(LenghtBox.Text);

            label.Content = sailboat.Hullspeed();
        }
    }
}
