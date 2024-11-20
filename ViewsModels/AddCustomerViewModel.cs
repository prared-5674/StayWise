using PropertyChanged;
using StayWise.Helpers;
using StayWise.Model;
using StayWise.Models;
using StayWise.Services;
using StayWise.Views;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace StayWise.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AddCustomerViewModel
    {
        private bool _isDirty;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;

        public CustomerDetails Customer { get; private set; }
        public RoomAllocation SelectedRoom { get; private set; }
        public bool HasUnsavedChanges => _isDirty && Customer.PersonalInfo.HasBasicInfo;

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand BrowseImageCommand { get; }
        public ICommand SelectRoomCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddCustomerViewModel()
        {
            Customer = new CustomerDetails();

            SaveCommand = new RelayCommand(async () => await SaveCustomerAsync(), () => CanSave());
            CancelCommand = new RelayCommand(async () => await TryCancelAsync());
            BrowseImageCommand = new RelayCommand(() => BrowseIdProof());

            SelectRoomCommand = new RelayCommand(ShowRoomSelection);
        }

        private void OnCustomerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!_isDirty && e.PropertyName?.StartsWith("PersonalInfo") == true)
            {
                _isDirty = true;
            }
        }

        private bool CanSave()
        {
            return !string.IsNullOrEmpty(Customer.PersonalInfo.FirstName) &&
                   !string.IsNullOrEmpty(Customer.PersonalInfo.PhoneNumber) &&
                   ValidateCustomer().IsValid;
        }

        private ValidationResult ValidateCustomer()
        {
            if (!Regex.IsMatch(Customer.PersonalInfo.PhoneNumber ?? "", @"^\d{10}$"))
                return new ValidationResult { IsValid = false, Message = "Invalid phone number" };

            if (!string.IsNullOrEmpty(Customer.PersonalInfo.Email) &&
                !Regex.IsMatch(Customer.PersonalInfo.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return new ValidationResult { IsValid = false, Message = "Invalid email format" };

            if (Customer.PersonalInfo.DateOfBirth.HasValue &&
                Customer.PersonalInfo.DateOfBirth.Value > DateTime.Now.AddYears(-18))
                return new ValidationResult { IsValid = false, Message = "Customer must be at least 18 years old" };

            return new ValidationResult { IsValid = true };
        }

        private async Task SaveCustomerAsync()
        {
            try
            {
                var validation = ValidateCustomer();
                if (!validation.IsValid)
                {
                    await _dialogService.ShowMessageAsync("Validation Error", validation.Message);
                    return;
                }

                Customer.CreatedDate = DateTime.Now;
                // TODO: Implement to database save logic here

                _isDirty = false;
                await _navigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                await _dialogService.ShowMessageAsync("Error", "Failed to save customer details: " + ex.Message);
            }
        }

        private void ShowRoomSelection()
        {
            var viewModel = new RoomSelectionViewModel();
            var window = new RoomSelectionWindow
            {
                DataContext = viewModel,
                Owner = Application.Current.MainWindow
            };

            viewModel.RequestClose += (result) =>
            {
                window.DialogResult = result;
                window.Close();
            };

            if (window.ShowDialog() == true)
            {
                SelectedRoom = viewModel.SelectedAllocation;
                _isDirty = true;
            }
        }

        private async Task TryCancelAsync()
        {
            if (HasUnsavedChanges)
            {
                var result = await _dialogService.ShowConfirmationAsync(
                    "Unsaved Changes",
                    "You have unsaved changes. Are you sure you want to discard them?");

                if (!result) return;
            }

            await _navigationService.GoBackAsync();
        }

        private void BrowseIdProof()
        {
            // TODO: Implement file browsing and image loading
        }
    }
}