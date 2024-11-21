using StayWise.ViewModels;
using System.Windows.Controls;

namespace StayWise.Views
{
    /// <summary>
    /// Interaction logic for AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : UserControl
    {
        public AddCustomerView()
        {
            InitializeComponent();
            this.DataContext = new AddCustomerViewModel();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.DataContext is AddCustomerViewModel viewModel)
            {
                viewModel.ShowRoomSelection();
                this.RoomNumber.Text = viewModel.SelectedRoom.RoomNumber.ToString();
                this.BedNumber.Text = viewModel.SelectedRoom.BedNumber.ToString();
                this.AmountValue.Text = viewModel.SelectedRoom.Amount.ToString();


            }
        }
    }
}
