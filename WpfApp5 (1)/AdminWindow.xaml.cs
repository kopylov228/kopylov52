using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp5
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void BtnManageUsers_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция управления пользователями будет добавлена позже",
                          "В разработке",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
        }

        private void BtnManageMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция управления меню будет добавлена позже",
                          "В разработке",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
        }

        private void BtnManageStaff_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция управления персоналом будет добавлена позже",
                          "В разработке",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
        }

        private void BtnFinancialStats_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция просмотра финансовой статистики будет добавлена позже",
                          "В разработке",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
        }

        private void BtnSystemSettings_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция системных настроек будет добавлена позже",
                          "В разработке",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
        }
    }
}