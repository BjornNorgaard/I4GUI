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

            FindTop10(1950);
            Top10listBox.ItemsSource = Top10BabyNames;

            #region Loading decades into DecadesListBox

            List<string> CollectionOfDecades = new List<string>();
            for (int i = 1900; i <= 2000; i += 10)
            {
                CollectionOfDecades.Add(i.ToString());
            }

            DecadeslistBox.ItemsSource = CollectionOfDecades;

            #endregion
        }

        public void FindTop10(int y)
        {
            // fill top10list with null babies all ranked last
            for (int i = 0; i < Top10BabyNames.Count; i++)
            {
                Top10BabyNames.Add(new BabyName("Derpo 0 0 0 0 0 0 0 0 0 0 0"));
            }

            BabyName babyName;
            
            for (int i = 0; i < CollectionOfBabyNames.Count; i++)
            {
                babyName = CollectionOfBabyNames[i];

                if (babyName.Rank(y) > Top10BabyNames[Top10BabyNames.Count-1].Rank(y))
                {
                    Top10BabyNames[9] = babyName;
                }

                #region Own sorting algorithme

                for (int j = 8; j >= 0; j--)
                {
                    if (Top10BabyNames[j + 1].Rank(y) > Top10BabyNames[j].Rank(y))
                    {
                        SwapTop10Babies(j + 1, j);
                    }
                }

                #endregion

                //#region With List<>.Sort

                //Top10BabyNames.Sort((x, z) => x.Rank(y).CompareTo(z.Rank(y)));

                //#endregion
            }
        }

        public void SwapTop10Babies(int indexOfBabyToGoUp, int indexOfBabyToGoDown)
        {
            BabyName temp = Top10BabyNames[indexOfBabyToGoDown];
            Top10BabyNames[indexOfBabyToGoDown] = Top10BabyNames[indexOfBabyToGoUp];
            Top10BabyNames[indexOfBabyToGoUp] = Top10BabyNames[indexOfBabyToGoDown];
        }
    }
}
