using System.Collections.ObjectModel;

namespace I4GUI_eksamen_2015_sommer_2.Views
{
    public class Plan : ObservableCollection<PlanItem>
    {
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