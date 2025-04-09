using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace GameStoreManager.Client.Core
{
    public class WindowManager
    {
        private readonly IServiceProvider _serviceProvider;

        public WindowManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Show<T>() where T : Window
        {
            var window = _serviceProvider.GetRequiredService<T>();
            window.Show();
        }
    }
}
