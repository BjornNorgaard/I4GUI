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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace I4GUI_eksamen_2016_sommer
{
    /// <summary>
    /// Interaction logic for SearchResults.xaml
    /// </summary>
    public partial class SearchResults : Window
    {
        public SearchResults(Jokes jokes)
        {
            InitializeComponent();
            foreach (Joke joke in jokes)
            {
                JokesList.Add(joke);
            }
        }

        private void ButtonBase_Luk_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
            OnCloseEvent();
        }

        public event EventHandler CloseEvent;

        protected virtual void OnCloseEvent()
        {
            CloseEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
