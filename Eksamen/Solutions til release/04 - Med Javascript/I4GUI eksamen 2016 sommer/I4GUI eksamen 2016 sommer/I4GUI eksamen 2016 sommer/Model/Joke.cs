﻿using System;
using System.Collections.Generic;
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
        private string[] _tags;
        private string _tagsSingleString;

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

        public string TagsSingleString
        {
            get { return _tagsSingleString; }
            set { _tagsSingleString = value; }
        }

        #endregion

        #region Constructors

        public Joke()
        {
            // I AM EMPTY BCUZ NEWTON JSON DESERIALIZATION :-)
        }

        public Joke(string jName, string jDate, string jSource, string tags)
        {
            Name = jName;
            Date = jDate;
            Source = jSource;
            Tags = tags.Split(',');
            TagsSingleString = tags;
        }

        #endregion

        #region Methods

        public bool ContainsTopic(string topic)
        {
            //foreach (string item in TagsSingleString)
            //{
            //    if (item.Contains(topic))
            //    {
            //        return true;
            //    }
            //}

            if (TagsSingleString.Contains(topic))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
