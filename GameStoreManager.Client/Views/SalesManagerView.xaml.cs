using GameStoreManager.Client.ViewModels;
using System.Windows;

namespace GameStoreManager.Client.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SalesManagerView.xaml
    /// </summary>
    public partial class SalesManagerView : Window
    {
        public SalesManagerViewModel ViewModel { get; set; }

        public SalesManagerView(SalesManagerViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }
    }
}
