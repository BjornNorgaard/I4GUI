using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyName
{
    public class BabyName
    {
        string m_name;
        int[] m_ranks;
        
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public BabyName(int[] rawRanks)
        {
            m_ranks = rawRanks;
        }

        public double AverageRank()
        {
            return 0;
        }

        public int Rank(int year)
        {
            return 1;
        }

        public string Trend(int year)
        {
            return "less popular";
        }
    }
}
