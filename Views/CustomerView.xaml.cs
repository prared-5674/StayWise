using StayWise.ViewsModels;
using System.Windows.Controls;

namespace StayWise.Views
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
            this.DataContext = new CustomerViewModel();
        }
    }
}
