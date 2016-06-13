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

        public string Name { get; set; }
        public string Date { get; set; }
        public string Source { get; set; }
        public List<string> TagListList { get; set; }

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
