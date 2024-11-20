using PropertyChanged;
using System.Collections.ObjectModel;

namespace StayWise.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Room
    {
        public int RoomNumber { get; set; }
        public int TotalBeds { get; set; }
        public decimal PricePerBed { get; set; }
        public ObservableCollection<Bed> Beds { get; set; } = new();
        public bool IsSelected { get; set; }
    }
}
