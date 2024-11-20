using PropertyChanged;
using System.Collections.ObjectModel;

namespace StayWise.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Floor
    {
        public int FloorNumber { get; set; }
        public ObservableCollection<Room> Rooms { get; set; } = new();
    }
}
