using GameStoreManager.Client.Core;
using GameStoreManager.Client.Models;
using GameStoreManager.Client.Services;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace GameStoreManager.Client.ViewModels
{
    public class SalesManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ISalesApiService _salesApiService;

        public ICommand LoadDataCommand { get; set; }

        public ObservableCollection<string> SaleDate { get; set; } = new();

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

        public SeriesCollection SaleCount
        {
            get { return _saleCount; }
            set
            {
                if (_saleCount != value)
                {
                    _saleCount = value;
                    OnPropertyChanged(nameof(SaleCount));
                }
            }
        }

        private SeriesCollection _saleCount;

        public SalesManagerViewModel(ISalesApiService salesApiService)
        {
            _salesApiService = salesApiService;
            LoadDataCommand = new RelayCommand(LoadData, CanLoadData);
        }

        private async void LoadData(object obj)
        {
            List<Sale> sales = await _salesApiService.GetSalesFromPeriod(StartDate, EndDate);
            
            DateTime timeToChange = StartDate.Date;

            SaleDate.Clear();
            List<int> tymczasowa = new();
            while (timeToChange <= EndDate)
            {
                SaleDate.Add(timeToChange.ToString("yyyy-MM-dd"));
                tymczasowa.Add(sales.Where(x => x.DateOfPurchase.Date == timeToChange).Count());
                timeToChange = timeToChange.AddDays(1);
            }

            SaleCount = new()
            {
                new LineSeries()
                {
                    Title = "Sprzedano: ",
                    Values= new ChartValues<int>(tymczasowa)
                }
            };
        }

        private bool CanLoadData(object obj) => true;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
