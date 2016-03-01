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
        public MainWindow()
        {
            InitializeComponent();

            Binding id_binding = new Binding();
            id_binding.Source = _agent;
            id_binding.Path = new PropertyPath("_agent.Id");
            IdTextBlock.SetBinding(TextBox.TextProperty, id_binding);
        }

        Agent _agent = new Agent("007", "James Bond", "Assasinations", "Danish Parlament");

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _agent.Id = IdTextBox.Text;
            IdTextBlock.Text = _agent.Id;
        }
    }
}
