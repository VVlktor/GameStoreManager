using GameStoreManager.Client.Core;
using GameStoreManager.Client.Views;
using System.Windows.Input;

namespace GameStoreManager.Client.ViewModels
{
    public class MainViewModel
    {
        private WindowManager _windowManager;

        public ICommand GoToAuctionManagerCommand { get; set; }
        public ICommand GoToSalesManagerCommand { get; set; }

        public MainViewModel(WindowManager windowManager)
        {
            _windowManager = windowManager;
            GoToAuctionManagerCommand = new RelayCommand(ShowAuctionManager, CanShowAuctionManager);
            GoToSalesManagerCommand = new RelayCommand(ShowSalesManager, CanShowSalesManager);
        }

        private void ShowSalesManager(object obj)
        {
            _windowManager.Show<SalesManagerView>();
        }

        private bool CanShowSalesManager(object obj) => true;

        public void ShowAuctionManager(object obj)
        {
            _windowManager.Show<AuctionManagerView>();
        }

        private bool CanShowAuctionManager(object obj) => true;
    }
}
