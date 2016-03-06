using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BabyNameToolSet
{
    public class BabyNameToolSet
    {
        #region Variables and Properties

        public List<BabyName> TotalListOfBabyNames { get; } = new List<BabyName>();
        readonly List<BabyName> _top20BothGenderBabyNames = new List<BabyName>();

        public List<string> Top10List { get; } = new List<string>();

        readonly string _pathToBabyNameFile = "babynames.txt";

        #endregion

        #region Constructors

        public BabyNameToolSet()
        {
            LoadBabyNamesIntoCollection(_pathToBabyNameFile);
        }

        public BabyNameToolSet(string pathToBabyNameFile)
        {
            _pathToBabyNameFile = pathToBabyNameFile;

            LoadBabyNamesIntoCollection(_pathToBabyNameFile);
        }

        #endregion

        private void LoadBabyNamesIntoCollection(string pathToBabyNameFile)
        {
            string[] lines = System.IO.File.ReadAllLines(_pathToBabyNameFile);

            for (int i = 0; i < lines.Length; i++)
            {
                TotalListOfBabyNames.Add(new BabyName(lines[i]));
            }
        }

        public void DetermineTop10ForGivenYear(int year)
        {
            List<BabyName> SortedList = TotalListOfBabyNames.OrderBy(o => o.Rank(year)).ToList();
            _top20BothGenderBabyNames.Clear();
            Top10List.Clear();

            for (int i = 0; i < 20; i++)
            {
                _top20BothGenderBabyNames.Add(SortedList[i]);
            }

            for (int i = 0; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    Top10List.Add(i + ". " + _top20BothGenderBabyNames[i] + " and ");
                }
                else if (i % 2 != 0)
                {
                    Top10List[i - 1] += _top20BothGenderBabyNames[i];
                }
            }
        }
    }
}
