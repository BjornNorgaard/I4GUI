using System;
using System.Collections.ObjectModel;

namespace I4GUI_eksamen_2015_sommer_2.Views
{
    public class Plan : ObservableCollection<PlanItem>
    {
        public Plan()
        {
            Add(new PlanItem() {Description = "Morgenmad", Time = DateTime.Parse("08:00 AM")});
            Add(new PlanItem() {Description = "Vitaminpiller", Time = DateTime.Parse("12:00 AM") });
        }
    }
}