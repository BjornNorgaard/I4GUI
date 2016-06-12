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

namespace I4GUI_eksamen_2015_sommer_2.Views
{
    /// <summary>
    /// Interaction logic for CreatePlanWindow.xaml
    /// </summary>
    public partial class CreatePlanWindow : Window
    {
        public PlanItem newPlanItem { get; set; }

        public CreatePlanWindow()
        {
            InitializeComponent();

            newPlanItem = new PlanItem();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newPlanItem.Time = DateTime.ParseExact(tbxTime.Text, "HHmm", CultureInfo.InvariantCulture);
                newPlanItem.Description = tbxDesc.Text;
                DialogResult = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("You done goofed: " + exception);
            }
        }
    }
}
