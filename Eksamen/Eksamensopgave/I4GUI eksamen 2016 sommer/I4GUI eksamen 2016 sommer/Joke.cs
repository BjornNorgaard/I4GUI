using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public Joke(string jName, string jDate, string jSource, string tags)
        {
            Name = jName;
            Date = jDate;
            Source = jSource;
            Tags = tags.Split(',');
        }

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
    }

    public class Jokes : ObservableCollection<Joke>, INotifyPropertyChanged
    {
        string filename = "";

        public Jokes()
        {
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                Add(new Joke("Hvorfor gik kyllingen over vejen? For at komme over på den anden side.", 
                    "13.6.2016", "PHP-bog", "kylling, gåde"));
            }
        }
    }
}
