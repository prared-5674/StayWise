using StayWise.Models;
using System.Collections.ObjectModel;

namespace StayWise.Service
{
    public class ActivityLogger
    {
        private readonly ObservableCollection<RecentActivity> _activities;
        private const int MaxActivities = 50;

        public ActivityLogger(ObservableCollection<RecentActivity> activities)
        {
            _activities = activities;
        }

        public void LogNewResident(string residentName, string roomNumber)
        {
            AddActivity(new RecentActivity
            {
                Type = ActivityType.NewResident,
                Message = $"New resident {residentName} admitted to Room {roomNumber}",
                RoomNumber = roomNumber,
                Time = DateTime.Now
            });
        }

        public void LogPayment(string residentName, decimal amount, string roomNumber)
        {
            AddActivity(new RecentActivity
            {
                Type = ActivityType.Payment,
                Message = $"Payment of ₹{amount:N0} received from {residentName}",
                Amount = amount,
                RoomNumber = roomNumber,
                Time = DateTime.Now
            });
        }

        public void LogRoomStatusChange(string roomNumber, string status, string reason = null)
        {
            var message = $"Room {roomNumber} status changed to {status}";
            if (!string.IsNullOrEmpty(reason))
                message += $" ({reason})";

            AddActivity(new RecentActivity
            {
                Type = ActivityType.RoomStatus,
                Message = message,
                RoomNumber = roomNumber,
                Time = DateTime.Now
            });
        }

        public void LogMaintenanceRequest(string roomNumber, string issue)
        {
            AddActivity(new RecentActivity
            {
                Type = ActivityType.Maintenance,
                Message = $"Maintenance request for Room {roomNumber}: {issue}",
                RoomNumber = roomNumber,
                Time = DateTime.Now
            });
        }

        private void AddActivity(RecentActivity activity)
        {
            _activities.Insert(0, activity);
            if (_activities.Count > MaxActivities)
                _activities.RemoveAt(_activities.Count - 1);
        }
    }
}
