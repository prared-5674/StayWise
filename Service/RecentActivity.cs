using System;
using System.Collections.ObjectModel;
using PropertyChanged;
using System.Windows.Media;
using System.Windows;

namespace StayWise.Models
{
    public enum ActivityType
    {
        NewResident,
        Payment,
        RoomStatus,
        Maintenance
    }

    [AddINotifyPropertyChangedInterface]
    public class RecentActivity
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public ActivityType Type { get; set; }
        public string RoomNumber { get; set; }
        public decimal? Amount { get; set; }

        public string TimeAgo
        {
            get
            {
                var span = DateTime.Now - Time;
                if (span.TotalMinutes < 60) return $"{(int)span.TotalMinutes} minutes ago";
                if (span.TotalHours < 24) return $"{(int)span.TotalHours} hours ago";
                return $"{(int)span.TotalDays} days ago";
            }
        }

        public SolidColorBrush ActivityColor => Type switch
        {
            ActivityType.NewResident => (SolidColorBrush)Application.Current.Resources["color2"],
            ActivityType.Payment => (SolidColorBrush)Application.Current.Resources["color3"],
            ActivityType.RoomStatus => (SolidColorBrush)Application.Current.Resources["color8"],
            ActivityType.Maintenance => (SolidColorBrush)Application.Current.Resources["color4"],
            _ => (SolidColorBrush)Application.Current.Resources["plainTextColor1"]
        };
    }
}