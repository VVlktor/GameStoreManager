using GameStoreManager.Client.ViewModels;
using System.Windows;

namespace GameStoreManager.Client.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AuctionManagerView.xaml
    /// </summary>
    public partial class AuctionManagerView : Window
    {
        private AuctionManagerViewModel viewModel;

        public AuctionManagerView(AuctionManagerViewModel auctionManagerViewModel)
        {
            InitializeComponent();
            viewModel = auctionManagerViewModel;
            DataContext = viewModel;
        }
    }
}
