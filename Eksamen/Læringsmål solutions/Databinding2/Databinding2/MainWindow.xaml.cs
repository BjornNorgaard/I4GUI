using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Databinding2.Annotations;

namespace Databinding2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person _person;

        public MainWindow()
        {
            InitializeComponent();
            _person = new Person("Tom", 1);
            DataContext = _person;
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _person.Age++;
        }
    }

    public class Person : INotifyPropertyChanged
    {
        private string _name;
        private int _age;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Notity();
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Notity();
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void Notity([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
