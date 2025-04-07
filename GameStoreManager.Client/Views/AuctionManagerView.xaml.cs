using GameStoreManager.Client.ViewModels;
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
