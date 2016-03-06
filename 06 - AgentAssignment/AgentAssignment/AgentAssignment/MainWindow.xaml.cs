using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using I4GUI;

namespace AgentAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Agents _agents = new Agents();

        public MainWindow()
        {
            InitializeComponent();

            _agents.Add(new Agent("666", "Sir", "Derping", "Engineering"));
            _agents.Add(new Agent("006", "Jaymes", "Blond", "Singing"));

            Grid.DataContext = _agents;
        }
    }
}
