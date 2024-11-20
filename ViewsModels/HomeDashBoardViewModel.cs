using LiveCharts.Wpf;
using LiveCharts;
using PropertyChanged;
using StayWise.Helpers;
using StayWise.Models;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows;
using StayWise.Service;

namespace StayWise.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public class HomeDashBoardViewModel
    {
        private readonly ActivityLogger _activityLogger;

        public int TotalResidents { get; set; }
        public int AvailableRooms { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public SeriesCollection RevenueData { get; set; }
        public ObservableCollection<RecentActivity> RecentActivities { get; private set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public HomeDashBoardViewModel()
        {
            RecentActivities = new ObservableCollection<RecentActivity>();
            _activityLogger = new ActivityLogger(RecentActivities);
            LoadDashboardData();
            InitializeChartData();
            InitializeRecentActivities();
        }

        private void LoadDashboardData()
        {
            TotalResidents = 156;
            AvailableRooms = 24;
            MonthlyRevenue = 245000;
        }

        private void InitializeChartData()
        {
            RevenueData = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<decimal> { 125000, 150000, 175000, 140000 },
                    Fill = (SolidColorBrush)Application.Current.Resources["color2"]
                },
                new ColumnSeries
                {
                    Title = "Occupancy",
                    Values = new ChartValues<int> { 25, 30, 35, 28 },
                    Fill = (SolidColorBrush)Application.Current.Resources["color3"]
                }
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr" };
            YFormatter = value => value.ToString("C");
        }

        private void InitializeRecentActivities()
        {
            _activityLogger.LogNewResident("John Doe", "302");
            _activityLogger.LogPayment("John Doe", 12000, "302");
            _activityLogger.LogMaintenanceRequest("205", "Water leakage in bathroom");
        }

        public void LogNewResident(string name, string roomNumber) =>
            _activityLogger.LogNewResident(name, roomNumber);

        public void LogPayment(string residentName, decimal amount, string roomNumber) =>
            _activityLogger.LogPayment(residentName, amount, roomNumber);

        public void LogRoomStatus(string roomNumber, string status, string reason = null) =>
            _activityLogger.LogRoomStatusChange(roomNumber, status, reason);

        public void LogMaintenance(string roomNumber, string issue) =>
            _activityLogger.LogMaintenanceRequest(roomNumber, issue);

        public void RefreshDashboard()
        {
            LoadDashboardData();
            InitializeChartData();
        }
    }
}