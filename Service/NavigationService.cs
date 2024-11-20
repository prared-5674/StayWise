using StayWise.Services;
using System.Windows;
using System.Threading.Tasks;
using StayWise.Views;

namespace StayWise.Service
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync()
        {
            if (Application.Current.MainWindow is DashBoardView mainWindow)
            {
                // Implement your navigation logic here
                // Example: mainWindow.NavigateBack();
            }
            return Task.CompletedTask;
        }

        public Task NavigateToAsync(string route)
        {
            if (Application.Current.MainWindow is DashBoardView mainWindow)
            {
                // Implement your navigation logic here based on your navigation system
                // Example: mainWindow.NavigateTo(route);
            }
            return Task.CompletedTask;
        }
    }
}
