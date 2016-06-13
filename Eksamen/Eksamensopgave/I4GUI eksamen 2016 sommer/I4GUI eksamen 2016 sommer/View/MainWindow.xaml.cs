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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace I4GUI_eksamen_2016_sommer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Jokes foundJokes = new Jokes();
        private FunnyImg _modelessWindow = null;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void ButtonBase_SearchTags_OnClick(object sender, RoutedEventArgs e)
        {
            //string tagsToSearchFor = TextBox_Search_Tags.ToString();

            //Jokes foundJokes = new Jokes();

            //foreach (Joke joke in (Jokes)ListBox_Jokes.ItemsSource)
            //{
            //    if (joke.ContainsTopic(tagsToSearchFor) == false)
            //    {
            //        foundJokes.Add(joke);
            //    }
            //}

            //ListBox_Jokes.ItemsSource = foundJokes;
        }

        private void MenuItem_FunnyImg_OnClick(object sender, RoutedEventArgs e)
        {
            if (_modelessWindow != null) _modelessWindow.Focus();
            else
            {
                _modelessWindow = new FunnyImg();
                _modelessWindow.Owner = this;
                _modelessWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                _modelessWindow.CloseEvent += Modeless_Closed;

                _modelessWindow.Show();
            }
        }

        private void Modeless_Closed(object sender, EventArgs e)
        {
            _modelessWindow = null;
            Focus();
        }
    }
}
