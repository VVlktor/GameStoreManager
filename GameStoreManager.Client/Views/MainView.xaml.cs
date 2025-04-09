using GameStoreManager.Client.ViewModels;
using System.Windows;

namespace GameStoreManager.Client.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private MainViewModel viewModel;

        public MainView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            viewModel = mainViewModel;
            DataContext = viewModel;
        }
    }
}
