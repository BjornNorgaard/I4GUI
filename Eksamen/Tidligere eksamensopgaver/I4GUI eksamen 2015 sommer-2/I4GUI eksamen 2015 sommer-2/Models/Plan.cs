using System;
using System.Collections.ObjectModel;

namespace I4GUI_eksamen_2015_sommer_2.Views
{
    public class Plan : ObservableCollection<PlanItem>
    {
        public Plan()
        {
            AddItem(new PlanItem() {Description = "Hello", Time = DateTime.Today});
            AddItem(new PlanItem() {Description = "Derp", Time = DateTime.Today});
            AddItem(new PlanItem() {Description = "ASDASD", Time = DateTime.Today});
            AddItem(new PlanItem() {Description = "ASDASD", Time = DateTime.Today});
            AddItem(new PlanItem() {Description = "ASDASD", Time = DateTime.Today});
        }

        public void AddItem(PlanItem item)
        {
            Add(item);
        }

        public void RemoveItem(PlanItem item)
        {
            Remove(item);
        }
    }
}