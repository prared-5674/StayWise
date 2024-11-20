using PropertyChanged;

namespace StayWise.Model
{
    [AddINotifyPropertyChangedInterface]
    public class OccupationInfo
    {
        public string Occupation { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
    }
}
