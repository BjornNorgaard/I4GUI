using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

            DetermineTop10BabyNamesForGivenYear(2000);
        }

        public void DetermineTop10BabyNamesForGivenYear(int y)
        {
            foreach (BabyName baby in CollectionOfBabyNames)
            {
                if (baby.Rank(y) < 11 && baby.Rank(y) != 0)
                {
                    Top20Babies.Add(baby);
                }
            }

            Top20Babies.Sort((a,b) => a.Rank(y).CompareTo(b.Rank(y)));
            Top10BabyNames.Clear();

            for (int i = 0; i < 10; i++)
            {
                Top10BabyNames.Add(i+1 + " " + Top20Babies[i].Name + " and " + Top20Babies[i+1].Name);
            }

            Top10listBox.ItemsSource = Top10BabyNames;

            Top10listBox.Items.Refresh();

            Debug.WriteLine("Source changed!");
        }

        private void DecadeslistBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetermineTop10BabyNamesForGivenYear((DecadeslistBox.SelectedIndex)*10+1900);
            //Top10listBox.UpdateLayout();
            Debug.WriteLine("DecadeslistBox_OnSelectionChanged called!");
        }

        private void Top10listBox_OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
        }
    }
}
