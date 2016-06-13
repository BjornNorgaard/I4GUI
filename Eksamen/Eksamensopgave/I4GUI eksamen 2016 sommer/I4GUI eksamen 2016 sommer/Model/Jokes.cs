using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using MvvmFoundation.Wpf;
using Newtonsoft.Json;

namespace I4GUI_eksamen_2016_sommer
{
    public class Jokes : ObservableCollection<Joke>, INotifyPropertyChanged
    {
        string filename = Directory.GetCurrentDirectory() + "\\jokes.json";
        
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
            if ((bool) (DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
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
            dlg.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (dlg.ShowDialog() == true)
            {
                Add(new Joke(dlg.Tekst, dlg.Date, dlg.Source, dlg.Tags));
                NotifyPropertyChanged("Count");
                CurrentIndex = Count - 1;
            }
        }

        #endregion

        #region Saving jokes

        ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(SaveFileCommand_Execute));
            }
        }

        private void SaveFileCommand_Execute()
        {
            string jsonOutput = JsonConvert.SerializeObject(this);

            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.Write(jsonOutput);
                sw.Close();
            }
        }

        private ICommand _loadCommand;

        public ICommand LoadCommand
        {
            get { return _loadCommand ?? (_loadCommand = new RelayCommand(LoadFileCommand_Execute)); }
        }
        private void LoadFileCommand_Execute()
        {
            if (File.Exists(filename))
            {
                string currentContent = File.ReadAllText(filename);
                Jokes someJokes = JsonConvert.DeserializeObject<Jokes>(currentContent);

                foreach (Joke joke in this)
                {
                    Remove(joke);
                }

                foreach (Joke item in someJokes)
                {
                    Add(item);
                }
            }
        }

        #endregion
    }
}