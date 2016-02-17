using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace _05___Baby_names
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BabyName> CollectionOfBabyNames = new List<BabyName>();
        List<BabyName> Top10BabyNames = new List<BabyName>(10); 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            #region Loading Raw babynamedata into BabyName class

            string[] lines = File.ReadAllLines("babynames.txt");    // used as temporary while loading

            // Convert raw data into BabyName class
            for (int i = 0; i < lines.Length; i++)
            {
                CollectionOfBabyNames.Add(new BabyName(lines[i]));
            }

            #endregion
            
            #region Loading decades into DecadesListBox

            List<string> CollectionOfDecades = new List<string>();
            for (int i = 1900; i <= 2000; i += 10)
            {
                CollectionOfDecades.Add(i.ToString());
            }

            DecadeslistBox.ItemsSource = CollectionOfDecades;

            #endregion
        }

        public void DetermineTop10BabyNamesForGivenYear(int y)
        {
            // all was poop, starting over
        }
    }
}
