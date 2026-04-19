using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyLogsVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<LogDto> AllLogs = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadLog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Archivos log (*.log;*.txt)|*.log;*.txt|Todos (*.*)|*.*";

            if (dialog.ShowDialog() == true)
            {
                AllLogs = LogConverter.Parse(dialog.FileName);
                ApplyFilter();
                //LogGrid.ItemsSource = AllLogs;
            }
        }

        private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //var text = SearchBox.Text.ToLower();

            //LogGrid.ItemsSource = AllLogs
            //    .Where(x =>
            //            (x.Message ?? "").ToLower().Contains(text) ||
            //            (x.Level ?? "").ToLower().Contains(text) ||
            //            (x.Timestamp ?? "").ToLower().Contains(text))
            //    .ToList();
            ApplyFilter();
        }

        private void LevelFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (AllLogs == null || !AllLogs.Any()) return;
            string text = SearchBox.Text.ToLower();
            string level = (LevelFilter.SelectedItem as ComboBoxItem)?.Content.ToString();

            var filtered = AllLogs.AsEnumerable();

            if (level != null && level != "Todos")
            {
                filtered = filtered.Where(l => l.Level == level);
            }

            if (!string.IsNullOrEmpty(text))
            {
                //LogGrid.ItemsSource = AllLogs
                filtered = filtered.Where(x =>
                        (x.Message ?? "").ToLower().Contains(text) ||
                        (x.Level ?? "").ToLower().Contains(text) ||
                        (x.Timestamp ?? "").ToLower().Contains(text))
                .ToList();
            }
            LogGrid.ItemsSource = filtered.ToList();
        }
    }
}