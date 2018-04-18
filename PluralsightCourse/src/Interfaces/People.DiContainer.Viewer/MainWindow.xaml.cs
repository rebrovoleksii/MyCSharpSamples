using System.Windows;

namespace People.DiContainer.Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;
        }

        private void GetPeopleList_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.FetchData();
            ShowRepositoryType();
        }

        private void ClearList_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ClearData();
        }


        private void ShowRepositoryType()
        {
            MessageBox.Show($"Repository Type:\n{_viewModel.RepositoryType}");
        }
    }
}
