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

namespace GUI_eksamen_sommer_2015
{
    /// <summary>
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public DateTime MedDateTime { get; set; }
        public string MedDescription { get; set; }

        public CreateWindow()
        {
            InitializeComponent();
        }
    }
}
