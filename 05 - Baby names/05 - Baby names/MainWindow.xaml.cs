﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace _05___Baby_names
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            #region Loading Raw babynamedata into Top10ListBox

            List<string> CollectionOfBabyNames = new List<string>();

            string[] lines = File.ReadAllLines("babynames.txt");

            // load ALL the names!
            for (int i = 0; i < lines.Length; i++)
            {
                CollectionOfBabyNames.Add(lines[i]);
            }

            Top10listBox.ItemsSource = CollectionOfBabyNames;

            #endregion

            List<string> CollectionOfDecades = new List<string>();
            for (int i = 1900; i <= 2000; i+=10)
            {
                CollectionOfDecades.Add(i.ToString());
            }

            DecadeslistBox.ItemsSource = CollectionOfDecades;
        }
    }
}
