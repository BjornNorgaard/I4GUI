using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4GUI_eksamen_2016_sommer
{
    [Serializable]
    public class Joke
    {
        #region Properties

        private string _name;
        private string _date;
        private string _source;
        private List<string> _tagListList;
        
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

        public List<string> TagListList
        {
            get { return _tagListList; }
            set { _tagListList = value; }
        }

        #endregion

        public Joke(string jName, string jDate, string jSource, List<string> jTagList)
        {
            Name = jName;
            Date = jDate;
            Source = jSource;
            TagListList = jTagList;
        }

        public bool ContainsTopic(string topic)
        {
            foreach (string item in TagListList)
            {
                if (item.Contains(topic))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
