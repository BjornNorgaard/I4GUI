using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace I4GUI
{
   public class Agents : ObservableCollection<Agent> { };  // Just to reference it from xaml

   [Serializable]
   public class Agent
   {
      string _id;
      string _codeName;
      string _speciality;
      string _assignment;

      public Agent()
      {
      }

      public Agent(string Id, string Name, string Address, string Speciality, string Assignment)
      {
         _id = Id;
         _codeName = Name;
         _speciality = Speciality;
         _assignment = Assignment;
      }

      public string Id
      {
         get
         {
            return _id;
         }
         set
         {
            _id = value;
         }
      }

      public string CodeName
      {
         get
         {
            return _codeName;
         }
         set
         {
            _codeName = value;
         }
      }

      public string Speciality
      {
         get
         {
            return _speciality;
         }
         set
         {
            _speciality = value;
         }
      }

      public string Assignment
      {
         get
         {
            return _assignment;
         }
         set
         {
            _assignment = value;
         }
      }
   }
}
