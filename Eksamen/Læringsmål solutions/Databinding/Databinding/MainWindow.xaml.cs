using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
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
using Databinding.Annotations;

namespace Databinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person person;

        public MainWindow()
        {
            InitializeComponent();

            person = new Person();
            person.PropertyChanged += Person_PropertyChanged;
        }

        private void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Name":
                    tbName.Text = person.Name;
                    break;
                case "Age":
                    tbAge.Text = person.Age.ToString();
                    break;
            }
        }
    }

    public class Person : INotifyPropertyChanged
    {
        public Person()
        {
            while (true)
            {
                Age++;
                Thread.Sleep(1000);
            }
        }

        public string Name
        {
            get { return Name; }
            set
            {
                if (Name == value) return;
                Name = value;
                Notify();
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age == value) return;
                _age = value;
                Notify();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
