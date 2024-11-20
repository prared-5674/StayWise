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
    }
}
