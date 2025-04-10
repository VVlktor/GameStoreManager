using GameStoreManager.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreManager.Client.ViewModels
{
    public class SalesManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ISalesApiService _salesApiService;

        public SalesManagerViewModel(ISalesApiService salesApiService)
        {
            _salesApiService = salesApiService;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

}
