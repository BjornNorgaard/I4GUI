using System.Windows;

namespace _04___Mouse_and_keyboard
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
            try
            {
                sailboat.Length = double.Parse(LenghtBox.Text);
            }
            catch (System.FormatException)
            {
                sailboat.Length = -1;
            }

            HSResultBlock.Text = sailboat.Hullspeed().ToString(format: "F");
        }
    }
}
