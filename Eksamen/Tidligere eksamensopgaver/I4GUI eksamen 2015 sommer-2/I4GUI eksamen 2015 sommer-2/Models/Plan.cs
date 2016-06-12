using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace I4GUI_eksamen_2015_sommer_2.Views
{
    public class Plan : ObservableCollection<PlanItem>, INotifyPropertyChanged
    {
    }
}