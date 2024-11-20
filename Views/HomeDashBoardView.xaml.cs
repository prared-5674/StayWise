using StayWise.ViewsModels;
using System.Windows.Controls;

namespace StayWise.Views
{
    /// <summary>
    /// Interaction logic for HomeDashBoardView.xaml
    /// </summary>
    public partial class HomeDashBoardView : UserControl
    {
        public HomeDashBoardView()
        {
            InitializeComponent();
            this.DataContext = new HomeDashBoardViewModel();
        }
    }
}
