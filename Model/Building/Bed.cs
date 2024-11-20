using PropertyChanged;

namespace StayWise.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Bed
    {
        public int BedNumber { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsSelected { get; set; }
    }
}
