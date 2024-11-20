﻿using PropertyChanged;

namespace StayWise.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string Landmark { get; set; }
    }
}
