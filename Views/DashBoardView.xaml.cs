﻿using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows;
using System.Windows.Interop;
using StayWise.ViewsModels;

namespace StayWise.Views
{
    /// <summary>
    /// Interaction logic for DashBoardView.xaml
    /// </summary>
    public partial class DashBoardView : Window
    {
        public DashBoardView()
        {
            InitializeComponent();
            MainContent.Content = new HomeDashBoardView();
            this.DataContext = new MainViewModel();

        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void ShowCustomerViewButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CustomerView();
        }

        private void ShowDashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new HomeDashBoardView();
        }

        private void ShowAddCustomerViewButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new AddCustomerView();
        }

        private void ShowAdminSettingButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new AdminSettingsView();
        }
    }
}