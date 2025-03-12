using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp5
{
    public partial class TablesWindow : Window
    {
        public TablesWindow()
        {
            InitializeComponent();
            CreateTables();
        }

        private void CreateTables()
        {
            for (int i = 1; i <= 12; i++)
            {
                var status = i % 3 == 0 ? "Занято" : (i % 2 == 0 ? "Резерв" : "Свободно");
                var background = status == "Занято" ? new SolidColorBrush(Color.FromRgb(244, 67, 54)) :
                               (status == "Резерв" ? new SolidColorBrush(Color.FromRgb(255, 193, 7)) :
                                new SolidColorBrush(Color.FromRgb(76, 175, 80)));

                var border = new Border
                {
                    Width = 150,
                    Height = 150,
                    Margin = new Thickness(10),
                    CornerRadius = new CornerRadius(10),
                    Background = background,
                    Tag = new { Number = i, Status = status }
                };

                var stackPanel = new StackPanel
                {
                    VerticalAlignment = VerticalAlignment.Center
                };

                var numberText = new TextBlock
                {
                    Text = i.ToString(),
                    FontSize = 24,
                    TextAlignment = TextAlignment.Center,
                    Foreground = Brushes.White
                };

                var statusText = new TextBlock
                {
                    Text = status,
                    FontSize = 16,
                    TextAlignment = TextAlignment.Center,
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 5, 0, 0)
                };

                var capacityText = new TextBlock
                {
                    Text = $"Мест: {(i % 2 == 0 ? 4 : 6)}",
                    FontSize = 14,
                    TextAlignment = TextAlignment.Center,
                    Foreground = Brushes.White
                };

                stackPanel.Children.Add(numberText);
                stackPanel.Children.Add(statusText);
                stackPanel.Children.Add(capacityText);

                border.Child = stackPanel;
                border.MouseDown += Table_MouseDown;

                TablesPanel.Children.Add(border);
            }
        }

        private void Table_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            var tableInfo = border.Tag as dynamic;
            var status = tableInfo.Status as string;

            if (status == "Свободно")
            {
                var result = MessageBox.Show(
                    $"Забронировать кабинку №{tableInfo.Number}?",
                    "Бронирование",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    border.Background = new SolidColorBrush(Color.FromRgb(255, 193, 7));
                    var stackPanel = border.Child as StackPanel;
                    var statusText = stackPanel.Children[1] as TextBlock;
                    statusText.Text = "Резерв";
                    tableInfo = new { Number = tableInfo.Number, Status = "Резерв" };
                    border.Tag = tableInfo;
                    MessageBox.Show("Кабинка успешно забронирована!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show($"Кабинка №{tableInfo.Number} {status.ToLower()}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}