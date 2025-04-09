using GameStoreManager.Client.Core;
using GameStoreManager.Client.Models;
using GameStoreManager.Client.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;

namespace GameStoreManager.Client.ViewModels
{
    public class AuctionManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand PostAnOfferCommand { get; set; }
        public ICommand AlterAnOfferCommand { get; set; }
        public ICommand DeleteOfferCommand { get; set; }

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

        private GameSaleOffer _gameOfferToAdd = new();
        public GameSaleOffer GameOfferToAdd
        {
            get => _gameOfferToAdd;
            set
            {
                _gameOfferToAdd = value;
                OnPropertyChanged(nameof(GameOfferToAdd));
            }
        }

        private string _unexpectedLeftError;
        public string UnexpectedLeftError
        {
            get => _unexpectedLeftError;
            set
            {
                _unexpectedLeftError = value;
                OnPropertyChanged(nameof(UnexpectedLeftError));
            }
        }

        private string _unexpectedRightError;
        public string UnexpectedRightError
        {
            get => _unexpectedRightError;
            set
            {
                _unexpectedRightError = value;
                OnPropertyChanged(nameof(UnexpectedRightError));
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
            DeleteOfferCommand = new RelayCommand(DeleteOffer, CanDeleteOffer);
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
            try
            {
                GameSaleOffer offer = await _gameApiService.AddGameOffer(GameOfferToAdd);
                if(offer is not null)
                    ListOfGameOffers.Add(offer);
            }
            catch(Exception ex)
            {
                UnexpectedLeftError = $"Wystąpił nieoczekiwany błąd: {ex.Message}";
            }
        }

        private bool CanAlterOffer(object obj) => true;

        private async void AlterOffer(object obj)
        {
            if (ListOfGameOffers.Count <= 0 || SelectedGameEdit is null)
                return;

            try
            {
                await _gameApiService.UpdateGameOffer(SelectedGameEdit);
            }
            catch(HttpRequestException ex)
            {
                UnexpectedRightError = $"Wystąpił nieoczekiwany błąd: {ex.Message}";
            }
            
        }

        private bool CanDeleteOffer(object obj) => true;

        private async void DeleteOffer(object obj)
        {
            if (ListOfGameOffers.Count <= 0)
                return;

            try
            {
                bool isSuccess = await _gameApiService.DeleteGameOffer(SelectedGameEdit);

                if (!isSuccess)
                    return;

                ListOfGameOffers.Remove(SelectedGameEdit);
                SelectedGameEdit = ListOfGameOffers.FirstOrDefault()!;
            }
            catch(HttpRequestException ex)
            {
                UnexpectedRightError = $"Wystąpił nieoczekiwany błąd: {ex.Message}";
            }
        }
    }
}
