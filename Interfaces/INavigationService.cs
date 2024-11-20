namespace StayWise.Services
{
    public interface INavigationService
    {
        Task GoBackAsync();
        Task NavigateToAsync(string route);
    }
}