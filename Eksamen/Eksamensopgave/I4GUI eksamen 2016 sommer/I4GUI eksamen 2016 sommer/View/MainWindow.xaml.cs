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

namespace I4GUI_eksamen_2016_sommer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //JokesList foundJokes = new JokesList();
        private FunnyImg _funnyImageWindow = null;
        private SearchResults _searchResultsWindow = null;

        public MainWindow()
        {
            InitializeComponent();
            Closing += Before_Closing;
        }

        private void Before_Closing(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void ButtonBase_SearchTags_OnClick(object sender, RoutedEventArgs e)
        {
            string tagToSearchFor = TextBox_Search_Tags.ToString();
            Properties.Settings.Default.resentSearch = tagToSearchFor;

            Jokes foundJokes = new Jokes();

            foreach (Joke joke in JokesList)
            {
                if (joke.ContainsTopic(tagToSearchFor))
                {
                    foundJokes.Add(joke);
                }
            }
            
            if (_searchResultsWindow != null) _searchResultsWindow.Focus();
            else
            {
                _searchResultsWindow = new SearchResults(foundJokes);
                _searchResultsWindow.Owner = this;
                _searchResultsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                _searchResultsWindow.CloseEvent += SearchResultsClosed;

                _searchResultsWindow.Show();
            }
        }

        private void MenuItem_FunnyImg_OnClick(object sender, RoutedEventArgs e)
        {
            if (_funnyImageWindow != null) _funnyImageWindow.Focus();
            else
            {
                _funnyImageWindow = new FunnyImg();
                _funnyImageWindow.Owner = this;
                _funnyImageWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                _funnyImageWindow.CloseEvent += FunnyImageClosed;

                _funnyImageWindow.Show();
            }
        }
        private void SearchResultsClosed(object sender, EventArgs e)
        {
            _searchResultsWindow = null;
            Focus();
        }

        private void FunnyImageClosed(object sender, EventArgs e)
        {
            _funnyImageWindow = null;
            Focus();
        }

        private void MenuItem_Luk_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
