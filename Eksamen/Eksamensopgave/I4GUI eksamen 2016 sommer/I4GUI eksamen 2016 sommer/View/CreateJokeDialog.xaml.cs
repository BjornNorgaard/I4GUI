﻿using System;
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
    public partial class CreateJokeDialog : Window
    {
        public string Tekst { get; set; }
        public string  Date { get; set; }
        public string Source { get; set; }
        public string Tags { get; set; }

        public CreateJokeDialog()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            Tekst = TextBoxTekst.Text;
            Date = TextBoxDato.Text;
            Source = TextBoxSource.Text;
            Tags = TextBoxTags.Text;

            DialogResult = true;
        }
    }
}
