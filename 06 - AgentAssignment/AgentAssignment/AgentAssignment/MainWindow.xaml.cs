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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            _agents.Add(new Agent("007", "James Bond", "Martinis", "Makeing a beerrun"));
            _agents.Add(new Agent("006", "Nina", "Assasination", "Danish parlament"));

            GridName.DataContext = _agents;
        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {
            // add new agent to list
            _agents.Add(new Agent("000", "Unnamed", "No speciality", "No assignment"));
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (AgentListBox.SelectedIndex > 0)
            {
                AgentListBox.SelectedIndex--;
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (AgentListBox.SelectedIndex < AgentListBox.Items.Count)
            {
                AgentListBox.SelectedIndex++;
            }
        }
    }
}
