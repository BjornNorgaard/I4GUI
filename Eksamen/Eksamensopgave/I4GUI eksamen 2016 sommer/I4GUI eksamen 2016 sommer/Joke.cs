using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MvvmFoundation.Wpf;

namespace I4GUI_eksamen_2016_sommer
{
    [Serializable]
    public class Joke
    {
        #region Properties

        private string _name;
        private string _date;
        private string _source;
        private string[] _tags;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public string[] Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        #endregion

        #region Constructors

        public Joke()
        {

        }

        public Joke(string jName, string jDate, string jSource, string tags)
        {
            Name = jName;
            Date = jDate;
            Source = jSource;
            Tags = tags.Split(',');
        }

        #endregion

        #region Methods

        public bool ContainsTopic(string topic)
        {
            foreach (string item in Tags)
            {
                if (item.Contains(topic))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }

    public class Jokes : ObservableCollection<Joke>, INotifyPropertyChanged
    {
        string filename = "";

        #region INotifyPropertyChanged Eventimplementation

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region IndexNumber property

        public int IndexNumber
        {
            get { return _indexNumber; }
            set
            {
                if (_indexNumber != value)
                {
                    _indexNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        public Jokes()
        {
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                Add(new Joke("Hvorfor gik kyllingen over vejen? For at komme over på den anden side.", "13.6.2016", "PHP-bog", "kylling, gåde"));
                Add(new Joke("Hvorfor gik kalkunen over vejen? Fordi det var kyllingens fridag.", "14.6.2016", "Arthur", "kalkun, gåde"));
            }
        }

        ICommand _addCommand;
        private int _indexNumber;

        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddJoke)); }
        }

        private void AddJoke()
        {
            Add(new Joke());
            NotifyPropertyChanged("Count");

        }
    }
}
