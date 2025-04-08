using GameStoreManager.Client.Core;
using GameStoreManager.Client.Models;
using GameStoreManager.Client.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace GameStoreManager.Client.ViewModels
{
    public class AuctionManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand PostAnOfferCommand { get; set; }
        public ICommand AlterAnOfferCommand { get; set; }

        private IGameOffersApiService _gameApiService;

        public ObservableCollection<GameSaleOffer> ListOfGameOffers { get; set; } = new();
        public IEnumerable<string> GamePlatformList { get; set; } = new List<string>() { "PC", "Playstation 5", "Playstation 4", "Xbox Series X", "Xbox one" };

        private GameSaleOffer _selectedGameEdit;
        public GameSaleOffer SelectedGameEdit
        {
            get => _selectedGameEdit; set
            {
                if (_selectedGameEdit != value)
                {
                    _selectedGameEdit = value;
                    OnPropertyChanged(nameof(SelectedGameEdit));
                }
            }
        }

        private GameSaleOffer _gameOfferToAdd;
        public GameSaleOffer GameOfferToAdd
        {
            get => _gameOfferToAdd;
            set
            {
                _gameOfferToAdd = value;
                OnPropertyChanged(nameof(GameOfferToAdd));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AuctionManagerViewModel(IGameOffersApiService gameApiService)
        {
            _gameApiService = gameApiService;
            PostAnOfferCommand = new RelayCommand(PostAnOffer, CanPostAnOffer);
            AlterAnOfferCommand = new RelayCommand(AlterOffer, CanAlterOffer);
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var list = await _gameApiService.GetAllGameOffers();
            foreach (var game in list)
                ListOfGameOffers.Add(game);
        }

        private bool CanPostAnOffer(object obj) => true;


        private async void PostAnOffer(object obj)
        {
            await _gameApiService.AddGameOffer(GameOfferToAdd);
            ListOfGameOffers.Add(GameOfferToAdd);
        }

        private bool CanAlterOffer(object obj) => true;

        private async void AlterOffer(object obj)
        {
            await _gameApiService.UpdateGameOffer(SelectedGameEdit);
        }

    }
}
