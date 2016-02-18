using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace _05___Baby_names
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BabyName> CollectionOfBabyNames = new List<BabyName>();
        List<BabyName> Top20Babies = new List<BabyName>(20);
        List<string> Top10BabyNames = new List<string>(10);

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

            //DetermineTop10BabyNamesForGivenYear(2000);
        }

        public void DetermineTop10BabyNamesForGivenYear(int y)
        {
            // make sure list is empty, so the same name won't appear multiple times
            Top20Babies.Clear();
            Top10BabyNames.Clear();

            // find 20 most popular boy/girl names in given year
            foreach (BabyName babyName in CollectionOfBabyNames.Where(babyName => babyName.Rank(y) < 11 && babyName.Rank(y) > 0))
            {
                Top20Babies.Add(babyName);
            }

            // sort list by rank at given year
            Top20Babies.Sort((a, b) => a.Rank(y).CompareTo(b.Rank(y)));
            
            // compile top 10 list with boy/girl pair as one entry
            for (int i = 0; i < 10; i++)
            {
                Top10BabyNames.Add(i + 1 + " " + Top20Babies[i].Name + " and " + Top20Babies[i + 1].Name);
            }

            // set listbox source to top10 list
            Top10listBox.ItemsSource = Top10BabyNames;

            // update gui
            Top10listBox.Items.Refresh();
        }

        private void DecadeslistBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetermineTop10BabyNamesForGivenYear((DecadeslistBox.SelectedIndex) * 10 + 1900);
            Debug.WriteLine("DecadeslistBox_OnSelectionChanged called!");
        }
    }
}
