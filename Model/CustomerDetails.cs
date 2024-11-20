using PropertyChanged;
using StayWise.Model;

namespace StayWise.Models
{
    [AddINotifyPropertyChangedInterface]
    public class CustomerDetails
    {
        public int Id { get; set; }
        public PersonalInfo PersonalInfo { get; set; } = new();
        public OccupationInfo OccupationInfo { get; set; } = new();
        public Address HomeAddress { get; set; } = new();
        public Address CompanyAddress { get; set; } = new();
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}