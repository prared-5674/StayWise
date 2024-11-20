using PropertyChanged;

namespace StayWise.Model
{
    [AddINotifyPropertyChangedInterface]
    public class PersonalInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhone { get; set; }
        public string Email { get; set; }
        public string GovernmentIdType { get; set; }
        public string GovernmentIdNumber { get; set; }
        public byte[] IdProofImage { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }
        public string BloodGroup { get; set; }

        public bool HasBasicInfo => !string.IsNullOrEmpty(FirstName) ||
                                  !string.IsNullOrEmpty(PhoneNumber) ||
                                  !string.IsNullOrEmpty(Email);
    }
}
