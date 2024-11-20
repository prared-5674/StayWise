using PropertyChanged;

namespace StayWise.Models
{
    [AddINotifyPropertyChangedInterface]
    public class RoomAllocation
    {
        public int FloorNumber { get; set; }
        public string RoomNumber { get; set; }
        public int BedNumber { get; set; }
        public decimal Amount { get; set; }
        public bool IsSelected { get; set; }
    }
}
