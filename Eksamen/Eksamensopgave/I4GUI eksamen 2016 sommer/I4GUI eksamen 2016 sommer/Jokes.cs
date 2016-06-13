using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using MvvmFoundation.Wpf;

namespace I4GUI_eksamen_2016_sommer
{
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

        #region CurrentIndex property

        private int _currentIndex;

        public int CurrentIndex
        {
            get { return _currentIndex; }
            set
            {
                if (_currentIndex != value)
                {
                    _currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructor

        public Jokes()
        {
            //if ((bool) (DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                Add(new Joke("Hvorfor gik kyllingen over vejen? For at komme over på den anden side.", "13.6.2016",
                    "PHP-bog", "kylling, gåde"));
                Add(new Joke("Hvorfor gik kalkunen over vejen? Fordi det var kyllingens fridag.", "14.6.2016", "Arthur",
                    "kalkun, gåde"));
            }
        }

        #endregion
        
        #region Adding jokes

        ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddJoke)); }
        }

        private void AddJoke()
        {
            CreateJokeDialog dlg = new CreateJokeDialog();
            dlg.ShowDialog();
            
            Add(new Joke());
            NotifyPropertyChanged("Count");
            CurrentIndex = Count - 1;
        }

        #endregion
        
        #region Saving jokes

        ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                       (_saveCommand = new RelayCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute));
            }
        }

        private void SaveFileCommand_Execute()
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(Jokes));
            TextWriter writer = new StreamWriter(filename);
            // Serialize all the agents.
            serializer.Serialize(writer, this);
            writer.Close();
        }

        private bool SaveFileCommand_CanExecute()
        {
            return (filename != "") && (Count > 0);
        }

        #endregion
    }
}