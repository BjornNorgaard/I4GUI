using System.Windows;

namespace Hull_speed___del_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label.Content = (1.34 * System.Math.Sqrt(double.Parse(LenghtBox.Text)));
        }
    }
}
