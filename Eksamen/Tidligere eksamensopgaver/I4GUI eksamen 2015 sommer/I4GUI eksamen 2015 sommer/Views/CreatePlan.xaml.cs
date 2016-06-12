using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace I4GUI_eksamen_2015_sommer
{
    /// <summary>
    /// Interaction logic for CreatePlan.xaml
    /// </summary>
    public partial class CreatePlan : Window
    {
        public CreatePlan()
        {
            InitializeComponent();
        }

        public DateTime MedTime { get; set; }
        public string MedDescription { get; set; }

        private void Btn_OK_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                MedTime = DateTime.ParseExact(textBoxTime.Text, "HHmm", CultureInfo.InvariantCulture);
            }
            catch (Exception exception)
            {
                MessageBox.Show("You done goofed: " + exception);
            }
            MedDescription = textBoxDesc.ToString();

            DialogResult = true;
        }
    }
}
